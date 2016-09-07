import { Component, OnInit } from '@angular/core';
import { AboutData } from './AboutData';
import { CommandService } from '../services/commandService';
import { CommandDto } from '../services/commandDto';
import { AboutDataService } from '../services/aboutDataService';

@Component({
    selector: 'about',
    template: require('./about.component.html')
})

export class AboutComponent implements OnInit {

    public message: string;
    public model: AboutData;
    public submitted: boolean;
    public active: boolean;
    public AboutDataItems: AboutData[];

    constructor(private _commandService: CommandService, private _aboutDataService: AboutDataService) {
        this.message = "Hello from About";
        this._commandService.OnUndoRedo.subscribe(item => this.OnUndoRedoRecieved(item));
    }

    ngOnInit() {
        this.model = new AboutData(0, 'yes', false);
        this.submitted = false;
        this.active = true;
        this.GetAboutDataItems();
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

    // TODO remove the get All request and update the list using the return item
    public Delete(aboutItem: AboutData) {
        let myCommand = new CommandDto("DELETE", "ABOUT", aboutItem, "about");

        console.log(myCommand);
        this._commandService.Execute(myCommand)
            .subscribe(
            data => this.GetAboutDataItems(),
            error => console.log(error),
            () => console.log('Command executed')
            );
    }

    // TODO remove the get All request and update the list using the return item
    public onSubmit() {
        this.submitted = true;

        let myCommand = new CommandDto("ADD", "ABOUT", this.model, "about");

        if (this.model.Id > 0) {
            myCommand.CommandType = "UPDATE";
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

    public newAboutData() {
        this.model = new AboutData(0, 'yes', false);
        this.active = false;
        setTimeout(() => this.active = true, 0);
    }
    
    private OnUndoRedoRecieved(item) {
        this.GetAboutDataItems();
        console.log("OnUndoRedoRecieved About");
        console.log(item);
    }
}