import { Component, OnInit } from '@angular/core';
import { UserModel, ApplicationService } from '../application.service';
import { CookieService } from 'ngx-cookie-service';
import { Router } from '@angular/router';
import { routerNgProbeToken } from '@angular/router/src/router_module';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-personal',
  templateUrl: './personal.component.html',
  styleUrls: ['./personal.component.css']
})
export class PersonalComponent implements OnInit {

  model: UserModel
  constructor(private app: ApplicationService, private cookie: CookieService, private router: Router, private translate: TranslateService) { 
    this.app.getUser(this.cookie.get('userId')).subscribe(x=>this.model = x)
  }


  ngOnInit() {

  }

  submit(){
    this.app.putUser(this.model.userId, this.model).subscribe(x=>console.log('yes'))
    this.router.navigate(['/main'])
    location.reload()
  }

}
