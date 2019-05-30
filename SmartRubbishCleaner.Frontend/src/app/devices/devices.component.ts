import { Component, OnInit, ViewChild } from '@angular/core';
import { DeviceModel, ApplicationService, UserModel, PointModel } from '../application.service';
import { CookieService } from 'ngx-cookie-service';
import { isUndefined } from 'util';
import { modelGroupProvider } from '@angular/forms/src/directives/ng_model_group';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-devices',
  templateUrl: './devices.component.html',
  styleUrls: ['./devices.component.css']
})
export class DevicesComponent implements OnInit {

  model: DeviceModel[] = []
  user: UserModel = new UserModel({ userId: '', email: '', role: '', name:'' })
  userDevices: DeviceModel[] = []
  point: PointModel = new PointModel({x: 36.228528, y: 50.014850})
  zoom: number = 15
  constructor(private app: ApplicationService, private cookie: CookieService, private router: Router, private translate: TranslateService) {
  }

  ngOnInit() {
    console.log(this.cookie.get('userId'))
    if (!isUndefined(this.cookie.get('userId')) && this.cookie.get('userId')!== '') {
      this.app.getUser(this.cookie.get('userId')).subscribe(x => {
        this.user = x
        this.getDevices()
      })
    }
  }

  getDevices() {
    this.app.getDevices().subscribe(x => {
      this.model = x
      this.Filter()
    })
    console.log(this.user)
  }

  Filter() {
    let userId = this.cookie.get('userId')
    for (let m of this.model) {
      if (m.owner.userId == userId) {
        this.userDevices.push(m)
      }
    }

  }

  delete(m: DeviceModel){
    m.owner = null
    this.app.putDevice(m.deviceId, m).subscribe(x=>{
      this.userDevices.splice(this.userDevices.indexOf(m), 1)
    })
  }

  cleanings(m: DeviceModel){
    this.cookie.set('deviceId', m.deviceId+"")
    this.router.navigate(['/cleanings'])
  }

  redirect(){
    this.router.navigate(['/devices/add'])
  }

}
