import { Component, OnInit } from '@angular/core';
import { ApplicationService, DeviceModel, UserModel } from 'src/app/application.service';
import { CookieService } from 'ngx-cookie-service';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {
  id: number = 0
  model: DeviceModel
  user: UserModel = new UserModel({ userId: '', email: '', role: '', name:'' })
  constructor(private app: ApplicationService, private cookie: CookieService, private router: Router, private translate: TranslateService) {
    this.app.getUser(this.cookie.get('userId')).subscribe(x=>this.user=x)
   }

  ngOnInit() {
  }

  add(){
    console.log(this.id)
    this.app.getDevice(this.id).subscribe(x=>{
     this.model = x
     this.Put() 
    })
  }

  Put(){
    console.log(this.model)
    this.model.owner = this.user
    this.app.putDevice(this.id, this.model).subscribe(x=>{
      console.log(x)
      this.router.navigate(['/devices'])
      location.reload()
    })
  }


}
