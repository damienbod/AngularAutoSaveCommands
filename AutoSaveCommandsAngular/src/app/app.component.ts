import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CommandService } from './services/command-service';
import { CommandDto } from './services/command-dto';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
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
