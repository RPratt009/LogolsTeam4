import { Inject } from '@angular/core';
import { Http } from '@angular/http';
import { StreamerList } from '../entities/streamerList';

export class StreamerService {
    http: Http;
    baseUrl: string;
    controller: string = "api/Streamer/";

    constructor(http: Http, baseUrl: string) {
        this.http = http;
        this.baseUrl = baseUrl;
    }
        
    public getAll() {
        return this.http.get(this.baseUrl + this.controller + "All");
    }
    
    public get(id: number) {
        return this.http.get(this.baseUrl + this.controller + id);
    }

    public getSubscriptions(userId: number) {
        return this.http.get(this.baseUrl + this.controller + "Subs/?userid=" + userId);
    }

    public insert(streamer: StreamerList) {
        streamer.Streamer = streamer.Channel;
        return this.http.post(this.baseUrl + this.controller, streamer);
    }
}