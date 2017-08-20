import { Observable } from 'rxjs/Observable';
import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'httprequestscomponent',
    templateUrl: 'httprequests.component.html'
})

export class HttpRequestsComponent {

    public message: string;
    public values: any[];

    constructor() {
        this.message = 'Hello from HttpRequestsComponent constructor';
    }
}