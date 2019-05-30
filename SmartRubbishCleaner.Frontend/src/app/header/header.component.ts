import { Component, OnInit } from '@angular/core';
import { UserModel, ApplicationService } from '../application.service';
import { CookieService } from 'ngx-cookie-service';
import { HeaderService } from '../header.service';
import { TestBed } from '@angular/core/testing';
import { isUndefined } from 'util';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  model: UserModel = new UserModel({ userId: '', email: '', role: '', name:'' })
  constructor(private cookie: CookieService, private head: HeaderService, private app: ApplicationService, private translate: TranslateService) {
    this.translate.setDefaultLang('en')
  }

  ngOnInit() {
    if (!isUndefined(this.cookie.get('userId')) && this.cookie.get('userId')!== '') {
      this.app.getUser(this.cookie.get('userId')).subscribe(x => {
        this.model = x
      })
    }
  }
  switchLanguage(lang: string){
    this.translate.use(lang)
  }

}
