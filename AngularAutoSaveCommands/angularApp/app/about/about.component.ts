
import {distinctUntilChanged, debounceTime} from 'rxjs/operators';
import { Component, OnInit } from '@angular/core';
import { AboutData } from './AboutData';
import { CommandService } from '../services/commandService';
import { CommandDto } from '../services/commandDto';
import { AboutDataService } from '../services/aboutDataService';

import { Observable ,  Subject } from 'rxjs';


@Component({
    selector: 'app-about-component',
    templateUrl: 'about.component.html'
})

export class AboutComponent implements OnInit {

    public message = '';
    public model: AboutData = { Id: 0, Description: '', Deleted: false };
    public submitted = false;
    public active = false;
    public AboutDataItems: AboutData[] = [];

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
        this.deboucedInput.pipe(
            debounceTime(1000),
            distinctUntilChanged())
            .subscribe(() => {
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
            () => this.GetAboutDataItems(),
            error => console.log(error),
            () => {
                if (this.model.Id === aboutItem.Id) {
                    this.newAboutData();
                }
            }
         );
    }

    public createCommand() {
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
