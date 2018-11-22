import { Component, OnInit } from '@angular/core';
import { CommandService } from '../services/commandService';

@Component({
    selector: 'app-commands-component',
    templateUrl: 'commands.component.html'
})

export class CommandsComponent implements OnInit {

    public message: string;
    public Commands: any[] = [];

    constructor(private _commandService: CommandService) {
        this.message = 'Hello from CommandsComponent constructor';
    }

    ngOnInit() {
        this.GetCommands();
    }

    public GetCommands() {
        this._commandService.GetAll()
            .subscribe((data) => {
                this.Commands = data;
            },
            error => console.log(error),
            () => {
                console.log('CommandsService:GetAll completed');
            }
            );
    }

}
