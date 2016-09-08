import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Http } from '@angular/http';
import { HomeData } from './HomeData';
import { CommandService } from '../services/commandService';
import { CommandDto } from '../services/commandDto';
import { HomeDataService } from '../services/homeDataService';

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
    selector: 'homecomponent',
    template: require('./home.component.html')
})

export class HomeComponent implements OnInit {

    public message: string;
    public model: HomeData;
    public submitted: boolean;
    public active: boolean;
    public HomeDataItems: HomeData[];

    private deboucedInput: Observable<string>;
    private keyDownEvents = new Subject<string>();

    constructor(private _commandService: CommandService, private _homeDataService: HomeDataService) {
        this.message = "Hello from Home";
        this._commandService.OnUndoRedo.subscribe(item => this.OnUndoRedoRecieved(item));

    }

    ngOnInit() {
        this.model = new HomeData(0, 'new home name', false);
        this.submitted = false;
        this.active = true;
        this.GetHomeDataItems();

        this.deboucedInput = this.keyDownEvents;
        this.deboucedInput
            .debounceTime(1000)       
            .distinctUntilChanged()   
            .subscribe((filter: string) => {
                this.onSubmit();
            });
    }

    public GetHomeDataItems() {
        console.log('HomeComponent starting...');
        this._homeDataService.GetAll()
            .subscribe((data) => {
                this.HomeDataItems = data;
            },
            error => console.log(error),
            () => {
                console.log('HomeDataService:GetAll completed');
            }
        );
    }

    public Edit(aboutItem: HomeData) {
        this.model.Name = aboutItem.Name;
        this.model.Id = aboutItem.Id;
    }

    // TODO remove the get All request and update the list using the return item
    public Delete(aboutItem: HomeData) {
        let myCommand = new CommandDto("DELETE", "HOME", aboutItem, "home");

        console.log(myCommand);
        this._commandService.Execute(myCommand)
            .subscribe(
            data => this.GetHomeDataItems(),
            error => console.log(error),
            () => console.log('Command executed')
            );
    }

    public createCommand(evt: any) {
        this.keyDownEvents.next(this.model.Name);
    }

    // TODO remove the get All request and update the list using the return item
    public onSubmit() {
        if (this.model.Name != "") {
            this.submitted = true;
            let myCommand = new CommandDto("ADD", "HOME", this.model, "home");

            if (this.model.Id > 0) {
                myCommand.CommandType = "UPDATE";
            }

            console.log(myCommand);
            this._commandService.Execute(myCommand)
                .subscribe(
                data => {
                    this.model.Id = data.Payload.Id;
                    this.GetHomeDataItems();
                },
                error => console.log(error),
                () => console.log('Command executed')
                );
        }       
    }

    public newHomeData() {
        this.model = new HomeData(0, 'new home item', false);
        this.active = false;
        setTimeout(() => this.active = true, 0);
    }

    private OnUndoRedoRecieved(payloadType) {
        if (payloadType === "HOME") {
            this.GetHomeDataItems();
            console.log("OnUndoRedoRecieved Home");
            console.log(payloadType);
        }       
    }
}