import { Component, OnInit } from '@angular/core';
import { TrashCanModel, DeviceModel, ApplicationService, PointModel } from 'src/app/application.service';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { TranslateService } from '@ngx-translate/core';
import { MouseEvent, MarkerManager } from '@agm/core';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class Add1Component implements OnInit {

  can: TrashCanModel = new TrashCanModel({ longtitude: 0, latitude: 0, deviceId: 0 })
  userDevices: DeviceModel[] = []
  devices: DeviceModel[] = []
  point: PointModel = new PointModel({ x: 36.228528, y: 50.014850 })
  subscription: string = this.cookie.get('subscription')
  marker: marker = { lat: this.point.y, lng: this.point.x }
  constructor(private app: ApplicationService, private router: Router, private cookie: CookieService, private translate: TranslateService) {

  }

  ngOnInit() {
    this.app.getDevices().subscribe(x => {
      this.devices = x
      this.Filter()
    })
  }

  Filter() {
    for (let d of this.devices) {
      if (d.owner.userId == this.cookie.get('userId')) {
        this.userDevices.push(d)
      }
    }
    console.log(this.userDevices)
  }

  add() {
    let value = (<HTMLSelectElement>document.getElementById('device')).value;
    this.can.deviceId = Number(value)
    this.app.postTrashCan(this.can).subscribe(x => {
      console.log(x)
    })
    this.router.navigate(['/cans'])
    location.reload()
  }

  mapClicked($event: MouseEvent) {
    this.can.latitude = $event.coords.lat
    this.can.longtitude = $event.coords.lng
    this.marker.lat = $event.coords.lat
    this.marker.lng = $event.coords.lng
  }

}

interface marker {
  lat: number;
  lng: number;
}
