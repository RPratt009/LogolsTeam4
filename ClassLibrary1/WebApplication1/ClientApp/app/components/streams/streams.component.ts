import { Component, Inject, EventEmitter, Input, Output } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Http } from '@angular/http';
import { UserLogin } from './../../entities/userLogin';
import { StreamerList } from './../../entities/streamerList';
import { UserSubscriptions } from './../../entities/userSubscriptions';
import { StreamerService } from './../../services/streamer.service';
import { SubscriptionService } from './../../services/subscription.service';

@Component({
    selector: 'streams',
    templateUrl: './streams.component.html'
})
export class StreamsComponent {

    public streamer: StreamerList;
    public streamerList: StreamerList[];
    public subscribedToList: StreamerList[];
    public subscriptionToAdd: UserSubscriptions;

    constructor(private route: ActivatedRoute, private http: Http, @Inject('BASE_URL') private baseUrl: string) { }

    ngOnInit() {
        this.reload();
    }

    reload() {
        this.streamer = { StreamerId:0, Streamer:"", Channel:"", Online:false };
        this.subscriptionToAdd = {subscriptionId:0, userLoginId:0, streamerId:0, sendEmail:0, position:0}
        let streamerService = new StreamerService(this.http, this.baseUrl);
        streamerService.getAll().subscribe(result => {
            this.streamerList = result.json() as StreamerList[];
        }, error => console.error(error));
        let streamerService2 = new StreamerService(this.http, this.baseUrl);
        streamerService2.getSubscriptions(2).subscribe(result => { 
            this.subscribedToList = result.json() as StreamerList[];
        }, error => console.error(error));
        
    }

    onAddClicked(streamAdded: StreamerList)
    {
        let streamerService = new StreamerService(this.http, this.baseUrl);
        streamerService.insert(streamAdded).subscribe(result => { this.reload(); }, error => console.error(error));
    }

    onSubscribe(streamerId: number)
    {
        let subscriptionService = new SubscriptionService(this.http, this.baseUrl);
        subscriptionService.insert(streamerId).subscribe(result => { this.reload(); }, error => console.error(error));
    }

    onDeleteSubscription(){
    }
}