import { Component, OnInit } from '@angular/core';
import { DeviceModel, ApplicationService } from 'src/app/application.service';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-admdevicesadd',
  templateUrl: './admdevicesadd.component.html',
  styleUrls: ['./admdevicesadd.component.css']
})
export class AdmdevicesaddComponent implements OnInit {

  dev: DeviceModel = new DeviceModel({actionRange: 0, maxVolume: 0, maxWeight: 0})
  constructor(private app: ApplicationService, private router: Router, private cookie: CookieService, private translate: TranslateService) { }

  ngOnInit() {

  }

  add(){
    this.app.postDevice(this.dev).subscribe(x=>this.router.navigate(['/administrate/devices']))
  }


}
