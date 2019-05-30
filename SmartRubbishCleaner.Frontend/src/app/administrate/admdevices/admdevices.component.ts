import { Component, OnInit } from '@angular/core';
import { DeviceModel, ApplicationService } from 'src/app/application.service';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-admdevices',
  templateUrl: './admdevices.component.html',
  styleUrls: ['./admdevices.component.css']
})
export class AdmdevicesComponent implements OnInit {

  devices: DeviceModel[] = []
  constructor(private app: ApplicationService, private router: Router, private cookie: CookieService, private translate: TranslateService) { }

  ngOnInit() {
    this.app.getDevices().subscribe(x=>this.devices=x)
  }

  delete(f: DeviceModel){
    this.app.deleteDevice(f.deviceId).subscribe(x=>this.devices.splice(this.devices.indexOf(f), 1))
  }

  edit(f: DeviceModel){
    this.cookie.set('deviceId', f.deviceId+'')
    this.router.navigate(['/administrate/devices/edit'])
  }

  add(){
    this.router.navigate(['/administrate/devices/add'])
  }

}
