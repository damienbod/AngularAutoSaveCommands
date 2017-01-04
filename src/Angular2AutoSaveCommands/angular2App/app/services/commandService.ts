import { Injectable, EventEmitter, Output } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';
import { Configuration } from '../app.constants';
import { CommandDto } from './CommandDto';

@Injectable()
export class CommandService {

    @Output() OnUndoRedo = new EventEmitter<string>();

    private actionUrl: string;
    private headers: Headers;

    constructor(private _http: Http, private _configuration: Configuration) {

        this.actionUrl = `${_configuration.Server}api/command/`;

        this.headers = new Headers();
        this.headers.append('Content-Type', 'application/json');
        this.headers.append('Accept', 'application/json');
    }

    public Execute = (command: CommandDto): Observable<CommandDto> => {
        let url = `${this.actionUrl}execute`;
        return this._http.post(url, command, { headers: this.headers }).map(res => res.json());
    }

    public Undo = (): Observable<CommandDto> => {
        let url = `${this.actionUrl}undo`;
        return this._http.post(url, '', { headers: this.headers }).map(res => res.json());
    }

    public Redo = (): Observable<CommandDto> => {
        let url = `${this.actionUrl}redo`;
        return this._http.post(url, '', { headers: this.headers }).map(res => res.json());
    }

    public GetAll = (): Observable<any> => {
        return this._http.get(this.actionUrl).map((response: Response) => <any>response.json());
    }

    public UndoRedoUpdate = (payloadType: string) => {
        this.OnUndoRedo.emit(payloadType);
    }
}