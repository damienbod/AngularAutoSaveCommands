import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CommandService } from './services/commandService';
import { CommandDto } from './services/commandDto';

// AoT compilation doesn't support 'require'.
import './app.component.scss';
import '../styles/app.scss';

@Component({
    selector: 'app-component',
    templateUrl: 'app.component.html'
})

export class AppComponent {

    constructor(private router: Router, private _commandService: CommandService) {
    }

    public Undo() {
        let resultCommand: CommandDto;

        this._commandService.Undo()
            .subscribe(
                data => resultCommand = data,
                error => console.log(error),
                () => {
                    this._commandService.UndoRedoUpdate(resultCommand.payloadType);
                    this.router.navigate(['/' + resultCommand.actualClientRoute]);
                }
            );
    }

    public Redo() {
        let resultCommand: CommandDto;

        this._commandService.Redo()
            .subscribe(
                data => resultCommand = data,
                error => console.log(error),
                () => {
                    this._commandService.UndoRedoUpdate(resultCommand.payloadType);
                    this.router.navigate(['/' + resultCommand.actualClientRoute]);
                }
            );
    }
}
