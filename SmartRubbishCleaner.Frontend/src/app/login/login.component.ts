import { Component, OnInit } from '@angular/core';
import { AuthModel, ApplicationService } from '../application.service';
import { RegisterService } from '../register.service';
import { CookieService } from 'ngx-cookie-service';
import { Router } from '@angular/router';
import { HeadListenerService } from '../head-listener.service';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  model: AuthModel = new AuthModel({email: '', password: '', rememberMe: false})
  id: string
  responseData: any
  constructor(private reg: RegisterService, private cookie: CookieService, private router: Router, private hl: HeadListenerService, private app: ApplicationService, private translate: TranslateService) {
    hl.onChange.subscribe(x => this.id = x)
  }

  ngOnInit() {
  }

  submit() {
    console.log(this.model)
    this.app.login(this.model).subscribe(x => {
      this.responseData = x
      this.login()
    })
  }

  login() {
    console.log(this.responseData)
    if (this.responseData!="Wrong credentials!") {
      this.cookie.set('userId', this.responseData.userid)
      this.hl.change(this.responseData.userid)
      this.router.navigate(['/main'])
      location.reload()
    }
    else {
      alert("Signing in failed!")
    }
  }

}
