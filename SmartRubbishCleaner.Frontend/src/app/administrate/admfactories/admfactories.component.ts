import { Component, OnInit } from '@angular/core';
import { ApplicationService, FactoryModel } from 'src/app/application.service';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-admfactories',
  templateUrl: './admfactories.component.html',
  styleUrls: ['./admfactories.component.css']
})
export class AdmfactoriesComponent implements OnInit {

  factories: FactoryModel[] = []
  constructor(private app: ApplicationService, private router: Router, private cookie: CookieService, private translate: TranslateService) { }

  ngOnInit() {
    this.app.getFactories().subscribe(x=>this.factories=x)
  }

  delete(f: FactoryModel){
    this.app.deleteFactory(f.factoryId).subscribe(x=>this.factories.splice(this.factories.indexOf(f), 1))
  }

  edit(f: FactoryModel){
    this.cookie.set('facId', f.factoryId+'')
    this.router.navigate(['/administrate/factories/edit'])
  }

  add(){
    this.router.navigate(['/administrate/factories/add'])
  }

}
