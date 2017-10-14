import { Component, Inject, EventEmitter, Input, Output } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Http } from '@angular/http';
import { UserLogin } from './../../entities/userLogin';
import { UserService } from './../../services/user.service';

@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})
export class HomeComponent {
    public user: UserLogin;
    public userToAdd: UserLogin;

    constructor(private route: ActivatedRoute, private http: Http, @Inject('BASE_URL') private baseUrl: string) { }

    ngOnInit() {
        this.reload();
    }

    reload() {
        this.user = { ID: 0, username: "", pass: "", email: "", layoutSelected: 0 };
        this.userToAdd = { ID: 0, username: "", pass: "", email: "", layoutSelected: 0 };
    }

    onGetClicked(user: UserLogin) {
        let userService = new UserService(this.http, this.baseUrl);
        userService.getCredentials(user.username, user.pass).subscribe(result => { this.handleLogin(result.status) }, error => console.error(error));
    }

    onAddClicked(user: UserLogin) {
        let userService = new UserService(this.http, this.baseUrl);
        userService.insert(user).subscribe(result => { this.reload(); }, error => console.error(error));
    }

    handleLogin(result: number) {
        if (result == 200)
        {
            window.location.href = 'streams';
        }
        else {
            this.reload();
        }
    }
}
