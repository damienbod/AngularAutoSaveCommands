import { Observable } from 'rxjs/Observable';
import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'httprequestscomponent',
    template: require('./httprequests.component.html')
})

export class HttpRequestsComponent implements OnInit {

    public message: string;
    public values: any[];

    constructor() {
        this.message = "Hello from HttpRequestsComponent constructor";
    }

    ngOnInit() {
       
    }
}
