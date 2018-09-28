import { Component, OnInit } from '@angular/core';
import { HomeData } from './HomeData';
import { CommandService } from '../services/commandService';
import { CommandDto } from '../services/commandDto';
import { HomeDataService } from '../services/homeDataService';

import { distinctUntilChanged, debounceTime } from 'rxjs/operators';
import { Observable ,  Subject } from 'rxjs';

@Component({
    selector: 'app-home-component',
    templateUrl: 'home.component.html'
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
        this.message = 'Hello from Home';
        this._commandService.OnUndoRedo.subscribe((item: any) => this.OnUndoRedoRecieved(item));
    }

    ngOnInit() {
        this.model = new HomeData(0, 'name', false);
        this.submitted = false;
        this.active = true;
        this.GetHomeDataItems();

        this.deboucedInput = this.keyDownEvents;
        this.deboucedInput.pipe(
            debounceTime(1000),
            distinctUntilChanged())
            .subscribe(() => {
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
    public Delete(homeItem: HomeData) {
        const myCommand = new CommandDto('DELETE', 'HOME', homeItem, 'home');

        console.log(myCommand);
        this._commandService.Execute(myCommand)
            .subscribe(
            () => this.GetHomeDataItems(),
            error => console.log(error),
            () => {
                if (this.model.Id === homeItem.Id) {
                    this.newHomeData();
                }
            }
        );
    }

    public createCommand() {
        this.keyDownEvents.next(this.model.Name);
    }

    public onSubmit() {
        if (this.model.Name !== '') {
            this.submitted = true;
            const myCommand = new CommandDto('ADD', 'HOME', this.model, 'home');

            if (this.model.Id > 0) {
                myCommand.CommandType = 'UPDATE';
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
        this.model = new HomeData(0, 'add a new name', false);
        this.active = false;
        setTimeout(() => this.active = true, 0);
    }

    private OnUndoRedoRecieved(payloadType: any) {
        if (payloadType === 'HOME') {
            this.GetHomeDataItems();
           // this.newHomeData();
            console.log('OnUndoRedoRecieved Home');
            console.log(payloadType);
        }
    }
}
