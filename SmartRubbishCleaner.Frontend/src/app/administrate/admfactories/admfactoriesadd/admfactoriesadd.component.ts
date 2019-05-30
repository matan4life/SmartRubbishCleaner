import { Component, OnInit } from '@angular/core';
import { FactoryModel, ApplicationService } from 'src/app/application.service';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-admfactoriesadd',
  templateUrl: './admfactoriesadd.component.html',
  styleUrls: ['./admfactoriesadd.component.css']
})
export class AdmfactoriesaddComponent implements OnInit {

  fac: FactoryModel = new FactoryModel({latitude: 0.0, longtitude: 0.0})
  constructor(private app: ApplicationService, private router: Router, private cookie: CookieService, private translate: TranslateService) { }

  ngOnInit() {
    this.app.getFactory(Number(this.cookie.get('facId'))).subscribe(x=>this.fac=x)
  }

  add(){
    this.app.postFactory(this.fac).subscribe(x=>this.router.navigate(['/administrate/factories']))
  }

}
