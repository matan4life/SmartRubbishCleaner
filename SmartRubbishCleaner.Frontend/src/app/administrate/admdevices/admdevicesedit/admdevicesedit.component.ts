import { Component, OnInit } from '@angular/core';
import { DeviceModel, ApplicationService } from 'src/app/application.service';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-admdevicesedit',
  templateUrl: './admdevicesedit.component.html',
  styleUrls: ['./admdevicesedit.component.css']
})
export class AdmdeviceseditComponent implements OnInit {

  dev: DeviceModel = new DeviceModel({actionRange: 0, maxVolume: 0, maxWeight: 0})
  constructor(private app: ApplicationService, private router: Router, private cookie: CookieService, private translate: TranslateService) { }

  ngOnInit() {
    this.app.getDevice(Number(this.cookie.get('deviceId'))).subscribe(x=>this.dev=x)
  }

  add(){
    this.app.putDevice(this.dev.deviceId, this.dev).subscribe(x=>this.router.navigate(['/administrate/devices']))
  }

}
