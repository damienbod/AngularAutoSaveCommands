import { Component } from '@angular/core';

@Component({
    selector: 'app-httprequests-component',
    templateUrl: 'httprequests.component.html'
})

export class HttpRequestsComponent {

    public message = '';
    public values: any[] = [];

    constructor() {
        this.message = 'Hello from HttpRequestsComponent constructor';
    }
}
