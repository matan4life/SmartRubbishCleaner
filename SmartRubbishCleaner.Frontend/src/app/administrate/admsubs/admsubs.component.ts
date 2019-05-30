import { Component, OnInit } from '@angular/core';
import { SubscriptionModel, ApplicationService } from 'src/app/application.service';
import { CookieService } from 'ngx-cookie-service';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-admsubs',
  templateUrl: './admsubs.component.html',
  styleUrls: ['./admsubs.component.css']
})
export class AdmsubsComponent implements OnInit {

  subs: SubscriptionModel[] = []
  constructor(private app: ApplicationService, private cookie: CookieService, private router: Router, private translate: TranslateService) { }

  ngOnInit() {
    this.app.getSubscriptions().subscribe(x=>this.subs=x)
  }

  delete(s: SubscriptionModel){
    this.app.deleteSubscription(s.subscriptionId).subscribe(x=>{
      this.subs.splice(this.subs.indexOf(s), 1)
      console.log(x)
    })
  }

  edit(s: SubscriptionModel){
    this.cookie.set('subId', s.subscriptionId+"")
    this.router.navigate(['/administrate/subs/edit'])
  }

  add(){
    this.router.navigate(['/administrate/subs/add'])
  }

}
