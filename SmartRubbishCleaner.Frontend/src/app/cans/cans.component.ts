import { Component, OnInit } from '@angular/core';
import { TrashCanModel, DeviceModel, ApplicationService, PointModel } from '../application.service';
import { CookieService } from 'ngx-cookie-service';
import { Router } from '@angular/router';
import { filter } from 'rxjs/operators';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-cans',
  templateUrl: './cans.component.html',
  styleUrls: ['./cans.component.css']
})
export class CansComponent implements OnInit {

  cans: TrashCanModel[] = []
  deviceCans: TrashCanModel[] = []
  devices: DeviceModel[] = []
  userDevices: DeviceModel[] = []
  point: PointModel = new PointModel({ x: 36.228528, y: 50.014850 })
  subscription: string = this.cookie.get('subscription')
  zoom: number = 15
  constructor(private app: ApplicationService, private cookie: CookieService, private router: Router, private translate: TranslateService) {

  }

  ngOnInit() {
    this.app.getDevices().subscribe(x => {
      this.devices = x
      this.app.getTrashCans().subscribe(y => {
        this.cans = y
        this.Filter()
      })
    })

  }

  Filter() {
    console.log(this.devices)
    console.log(this.cans)
    for (let d of this.devices) {
      if (d.owner.userId == this.cookie.get('userId')) {
        this.userDevices.push(d)
      }
    }
    for (let c of this.cans) {
      for (let d of this.userDevices) {
        if (d.deviceId == c.deviceId) {
          this.deviceCans.push(c)
          break
        }
      }
    }
    console.log(this.deviceCans)
  }

  redirect() {
    if (this.subscription=='Usual'){
      if (this.deviceCans.length>3){
        alert("Permission denied!")
        return
      }
    }
    this.router.navigate(['/cans/add'])
  }

}
