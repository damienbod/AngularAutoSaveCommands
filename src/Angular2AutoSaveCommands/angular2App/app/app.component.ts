import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CommandService } from './services/commandService';
import { CommandDto } from './services/commandDto';

@Component({
    selector: 'my-app',
    template: require('./app.component.html'),
    styles: [require('./app.component.scss'), require('../style/app.scss')]
})


export class AppComponent {

    constructor(private router: Router, private _commandService: CommandService,) {
    }

    public Undo() {
        let resultCommand: CommandDto;

        this._commandService.Undo()
            .subscribe(
            data => resultCommand = data,
            error => console.log(error),
            () => console.log(resultCommand); 
        );
    }

    public Redo() {
        let resultCommand: CommandDto;

        this._commandService.Redo()
            .subscribe(
            data => resultCommand = data,
            error => console.log(error),
            () => console.log(resultCommand)
            );
    }
}