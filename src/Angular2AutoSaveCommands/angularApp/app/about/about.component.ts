import { Component, OnInit } from '@angular/core';
import { AboutData } from './AboutData';
import { CommandService } from '../services/commandService';
import { CommandDto } from '../services/commandDto';
import { AboutDataService } from '../services/aboutDataService';

import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';

import 'rxjs/add/observable/of';
import 'rxjs/add/observable/throw';

// Observable operators
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/debounceTime';
import 'rxjs/add/operator/distinctUntilChanged';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/filter';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/switchMap';

@Component({
    selector: 'app-about-component',
    templateUrl: 'about.component.html'
})

export class AboutComponent implements OnInit {

    public message: string;
    public model: AboutData;
    public submitted: boolean;
    public active: boolean;
    public AboutDataItems: AboutData[];

    private deboucedInput: Observable<string>;
    private keyDownEvents = new Subject<string>();

    constructor(private _commandService: CommandService, private _aboutDataService: AboutDataService) {
        this.message = 'Hello from About';
        this._commandService.OnUndoRedo.subscribe((item: any) => this.OnUndoRedoRecieved(item));
    }

    ngOnInit() {
        this.model = new AboutData(0, 'description', false);
        this.submitted = false;
        this.active = true;
        this.GetAboutDataItems();

        this.deboucedInput = this.keyDownEvents;
        this.deboucedInput
            .debounceTime(1000)
            .distinctUntilChanged()
            .subscribe((filter: string) => {
                this.onSubmit();
            });
    }

    public GetAboutDataItems() {
        console.log('AboutComponent starting...');
        this._aboutDataService.GetAll()
            .subscribe((data) => {
                this.AboutDataItems = data;
            },
            error => console.log(error),
            () => {
                console.log('AboutDataService:GetAll completed');
            }
        );
    }

    public Edit(aboutItem: AboutData) {
        this.model.Description = aboutItem.Description;
        this.model.Id = aboutItem.Id;
    }

    public Delete(aboutItem: AboutData) {
        const myCommand = new CommandDto('DELETE', 'ABOUT', aboutItem, 'about');

        console.log(myCommand);
        this._commandService.Execute(myCommand)
            .subscribe(
            data => this.GetAboutDataItems(),
            error => console.log(error),
            () => {
                if (this.model.Id === aboutItem.Id) {
                    this.newAboutData();
                }
            }
         );
    }

    public createCommand(evt: any) {
        this.keyDownEvents.next(this.model.Description);
    }

    // TODO remove the get All request and update the list using the return item
    public onSubmit() {
        if (this.model.Description !== '') {
            this.submitted = true;

            const myCommand = new CommandDto('ADD', 'ABOUT', this.model, 'about');

            if (this.model.Id > 0) {
                myCommand.CommandType = 'UPDATE';
            }

            console.log(myCommand);
            this._commandService.Execute(myCommand)
                .subscribe(
                data => {
                    this.model.Id = data.Payload.Id;
                    this.GetAboutDataItems();
                },
                error => console.log(error),
                () => console.log('Command executed')
                );
        }
    }

    public newAboutData() {
        this.model = new AboutData(0, 'add a new description', false);
        this.active = false;
        setTimeout(() => this.active = true, 0);
    }

    private OnUndoRedoRecieved(payloadType: any) {
        if (payloadType === 'ABOUT') {
            this.GetAboutDataItems();
            // this.newAboutData();
            console.log('OnUndoRedoRecieved About');
            console.log(payloadType);
        }
    }
}
