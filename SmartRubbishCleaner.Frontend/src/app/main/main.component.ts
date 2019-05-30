import { Component, OnInit } from '@angular/core';
import { TrashCanModel, ApplicationService, UserModel, SubscriptionModel } from '../application.service';
import { CookieService } from 'ngx-cookie-service';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {
  user: UserModel = new UserModel({ userId: '', email: '', role: '', name:'' })
  subscription: SubscriptionModel = new SubscriptionModel({subscriptionId: 0, identificationName: '', price: 0})
  constructor(private app: ApplicationService, private cookie: CookieService, private translate: TranslateService) { }

  ngOnInit() {
    if (this.cookie.get('userId')!=""){
      this.app.getUser(this.cookie.get('userId')).subscribe(x=>this.user = x)
      this.app.getSubscription2(this.cookie.get('userId')).subscribe(x=>{
        this.subscription=x
        this.SetSub()
      })
    }
  }

  SetSub(){
    this.cookie.set('subscription', this.subscription.identificationName)
  }

}
