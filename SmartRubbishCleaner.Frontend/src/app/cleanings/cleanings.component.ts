import { Component, OnInit } from '@angular/core';
import { DeviceModel, ApplicationService, CleaningModel } from '../application.service';
import { CookieService } from 'ngx-cookie-service';
import { filter } from 'rxjs/operators';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-cleanings',
  templateUrl: './cleanings.component.html',
  styleUrls: ['./cleanings.component.css']
})
export class CleaningsComponent implements OnInit {

  cleanings: CleaningModel[] = []
  deviceCleanings: CleaningModel[] = []
  deviceNumber: number = 0
  device: DeviceModel = new DeviceModel({deviceId: 0})
  constructor(private app: ApplicationService, private cookie: CookieService, private translate: TranslateService) { }

  ngOnInit() {
    if (this.cookie.get('deviceId')!=''){
      this.deviceNumber=Number(this.cookie.get('deviceId'))
      this.app.getDevice(this.deviceNumber).subscribe(x=>this.device=x)
    }
    this.app.getCleanings().subscribe(x => {
      this.cleanings = x
      this.Filter()
    }
    )
  }
  Filter(){
    for (let c of this.cleanings){
      if (c.deviceId==Number(this.cookie.get('deviceId'))){
        this.deviceCleanings.push(c)
      }
    }
  }

}
