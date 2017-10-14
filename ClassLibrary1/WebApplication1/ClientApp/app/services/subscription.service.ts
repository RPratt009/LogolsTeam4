import { Inject } from '@angular/core';
import { Http } from '@angular/http';

export class SubscriptionService {
    http: Http;
    baseUrl: string;
    controller: string = "api/Subscription/";

    constructor(http: Http, baseUrl: string) {
        this.http = http;
        this.baseUrl = baseUrl;
    }

    public insert(streamerId: number) {
        alert(streamerId);
        return this.http.get(this.baseUrl + this.controller + streamerId);
    }
}