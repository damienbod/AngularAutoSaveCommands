import { Observable } from 'rxjs/Observable';
import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { HomeData } from './HomeData';
import { CommandService } from '../services/commandService';
import { CommandDto } from '../services/commandDto';
import { HomeDataService } from '../services/homeDataService';

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

    constructor(private _commandService: CommandService, private _homeDataService: HomeDataService) {
        this.message = "Hello from Home";
    }

    ngOnInit() {
        this.model = new HomeData(0, 'new home name', false);
        this.submitted = false;
        this.active = true;
        this.GetHomeDataItems();
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

    // TODO remove the get All request and update the list using the return item
    public onSubmit() {
        this.submitted = true;
        let myCommand = new CommandDto("ADD", "HOME", this.model, "home");

        if (this.model.Id > 0) {
            myCommand.CommandType = "UPDATE";
        }

        console.log(myCommand);
        this._commandService.Execute(myCommand)
            .subscribe(
            data => this.GetHomeDataItems(),
            error => console.log(error),
            () => console.log('Command executed')
            );
    }

    public newHomeData() {
        this.model = new HomeData(0, 'new home item', false);
        this.active = false;
        setTimeout(() => this.active = true, 0);
    }
}