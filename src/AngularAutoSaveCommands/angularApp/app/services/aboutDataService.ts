
import {map} from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';

import { Observable } from 'rxjs';
import { Configuration } from '../app.constants';

@Injectable()
export class AboutDataService {

    private actionUrl: string;
    private headers: Headers;

    constructor(private _http: Http, private _configuration: Configuration) {

        this.actionUrl = `${_configuration.Server}api/about/`;

        this.headers = new Headers();
        this.headers.append('Content-Type', 'application/json');
        this.headers.append('Accept', 'application/json');
    }

    public GetAll = (): Observable<any> => {
        return this._http.get(this.actionUrl).pipe(map((response: Response) => <any>response.json()));
    }
}
