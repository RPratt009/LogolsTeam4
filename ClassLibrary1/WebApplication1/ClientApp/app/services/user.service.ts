import { Inject } from '@angular/core';
import { Http } from '@angular/http';
import { UserLogin } from '../entities/userLogin';

export class UserService {
    http: Http;
    baseUrl: string;
    controller: string = "api/User/";

    constructor(http: Http, baseUrl: string) {
        this.http = http;
        this.baseUrl = baseUrl;
    }

    public get(id: number) {
        return this.http.get(this.baseUrl + this.controller + id);
    }

    public getCredentials(username: string, password: string) {
        return this.http.get(this.baseUrl + this.controller + username + '/' + password);
    }

    public update(user: UserLogin) {
        return this.http.put(this.baseUrl + this.controller, user);
    }

    public insert(user: UserLogin) {
        return this.http.post(this.baseUrl + this.controller, user);
    }
}