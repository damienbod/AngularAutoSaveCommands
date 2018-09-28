import { HttpClient, HttpHeaders } from '@angular/common/http';
﻿import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { Configuration } from '../app.constants';

@Injectable()
export class AboutDataService {

    private actionUrl: string;
    private headers: HttpHeaders;

    constructor(private http: HttpClient, configuration: Configuration) {

        this.actionUrl = `${configuration.Server}api/about/`;

        this.headers = new HttpHeaders();
        this.headers = this.headers.set('Content-Type', 'application/json');
        this.headers = this.headers.set('Accept', 'application/json');
    }

    public GetAll = (): Observable<any> => {
        return this.http.get<any>(this.actionUrl, { headers: this.headers });
    }
}
