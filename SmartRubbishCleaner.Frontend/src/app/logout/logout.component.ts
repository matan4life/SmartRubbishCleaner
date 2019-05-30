import { Component, OnInit } from '@angular/core';
import { ApplicationService } from '../application.service';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.css']
})
export class LogoutComponent implements OnInit {

  constructor(private app: ApplicationService, private r: Router, private cookie: CookieService) { }

  ngOnInit() {
    this.app.logOff()
    this.cookie.set('userId', '')
    this.r.navigate(['/main'])
    location.reload()
  }

}
