import { HttpClient, HttpHeaders } from '@angular/common/http';
﻿import { Injectable, EventEmitter, Output } from '@angular/core';
import { Observable } from 'rxjs';

import { Configuration } from '../app.constants';
import { CommandDto } from './CommandDto';

@Injectable()
export class CommandService {

    @Output() OnUndoRedo = new EventEmitter<string>();

    private actionUrl: string;
    private headers: HttpHeaders;

    constructor(private http: HttpClient, configuration: Configuration) {

        this.actionUrl = `${configuration.Server}api/command/`;

        this.headers = new HttpHeaders();
        this.headers = this.headers.set('Content-Type', 'application/json');
        this.headers = this.headers.set('Accept', 'application/json');
    }

    public Execute = (command: CommandDto): Observable<CommandDto> => {
        const url = `${this.actionUrl}execute`;
        return this.http.post<CommandDto>(url, command, { headers: this.headers });
    }

    public Undo = (): Observable<CommandDto> => {
        const url = `${this.actionUrl}undo`;
        return this.http.post<CommandDto>(url, '', { headers: this.headers });
    }

    public Redo = (): Observable<CommandDto> => {
        const url = `${this.actionUrl}redo`;
        return this.http.post<CommandDto>(url, '', { headers: this.headers });
    }

    public GetAll = (): Observable<any> => {
        return this.http.get<any>(this.actionUrl, { headers: this.headers });
    }

    public UndoRedoUpdate = (payloadType: string) => {
        this.OnUndoRedo.emit(payloadType);
    }
}
