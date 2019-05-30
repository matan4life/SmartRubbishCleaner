import { Component, OnInit } from '@angular/core';
import { SubscriptionModel, ApplicationService } from 'src/app/application.service';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-admsubsadd',
  templateUrl: './admsubsadd.component.html',
  styleUrls: ['./admsubsadd.component.css']
})
export class AdmsubsaddComponent implements OnInit {

  sub: SubscriptionModel = new SubscriptionModel({identificationName: "", price: 0.0})
  constructor(private app: ApplicationService, private router: Router, private translate: TranslateService) { }

  ngOnInit() {
  }

  add(){
    this.app.postSubscription(this.sub).subscribe(x=>this.router.navigate(['/administrate/subs']))
  }

}
