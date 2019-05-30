import { Component, OnInit } from '@angular/core';
import { FactoryModel, ApplicationService } from 'src/app/application.service';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-admfactoriesedit',
  templateUrl: './admfactoriesedit.component.html',
  styleUrls: ['./admfactoriesedit.component.css']
})
export class AdmfactorieseditComponent implements OnInit {

  fac: FactoryModel = new FactoryModel({latitude: 0.0, longtitude: 0.0})
  constructor(private app: ApplicationService, private router: Router, private cookie: CookieService, private translate: TranslateService) { }

  ngOnInit() {
    this.app.getFactory(Number(this.cookie.get('facId'))).subscribe(x=>this.fac=x)
  }

  edit(){
    this.app.putFactory(this.fac.factoryId, this.fac).subscribe(x=>this.router.navigate(['/administrate/factories']))
  }

}
