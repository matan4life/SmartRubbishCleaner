import { Component, OnInit } from '@angular/core';
import { SubscriptionModel, ApplicationService } from 'src/app/application.service';
import { CookieService } from 'ngx-cookie-service';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-admsubsedit',
  templateUrl: './admsubsedit.component.html',
  styleUrls: ['./admsubsedit.component.css']
})
export class AdmsubseditComponent implements OnInit {
  sub: SubscriptionModel = new SubscriptionModel({identificationName: "", price: 0})
  constructor(private app: ApplicationService, private cookie: CookieService, private router: Router, private translate: TranslateService) { }

  ngOnInit() {
    this.app.getSubscription(Number(this.cookie.get('subId'))).subscribe(x=>this.sub=x)
  }

  edit(){
    this.app.putSubscription(this.sub.subscriptionId, this.sub).subscribe(x=>this.router.navigate(['/administrate/subs']))
  }

}
