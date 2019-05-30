import { Component, OnInit } from '@angular/core';
import { RegisterService } from '../register.service';
import { UserRegisterRequestModel, ApplicationService } from '../application.service';
import { CookieService } from 'ngx-cookie-service';
import { Router } from '@angular/router';
import { HeadListenerService } from '../head-listener.service';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  model: UserRegisterRequestModel = new UserRegisterRequestModel({ email: '', rememberMe: false, role: 'user', password: '' })
  id: string
  responseData: any
  constructor(private reg: RegisterService, private cookie: CookieService, private router: Router, private hl: HeadListenerService, private app: ApplicationService, private translate: TranslateService) {
    hl.onChange.subscribe(x => this.id = x)
  }

  ngOnInit() {
  }

  submit() {
    this.app.registerAsync(this.model).subscribe(x => {
      this.responseData = x
      this.register()
    })
  }

  register() {
    console.log(this.responseData)
    if (this.responseData != "Result validation failed!") {
      this.cookie.set('userId', this.responseData.userid)
      this.hl.change(this.responseData.userid)
      this.router.navigate(['/main'])
      location.reload()
    }
    else {
      alert("Signing up failed")
    }
  }

}
