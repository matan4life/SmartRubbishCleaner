import { Component, OnInit } from '@angular/core';
import { UserModel, ApplicationService, UserRegisterRequestModel } from 'src/app/application.service';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-admusers',
  templateUrl: './admusers.component.html',
  styleUrls: ['./admusers.component.css']
})
export class AdmusersComponent implements OnInit {

  users: UserModel[] = []
  constructor(private app: ApplicationService, private translate: TranslateService) { }

  ngOnInit() {
    this.app.getUsers().subscribe(x=>{
      this.users=x
    })
  }

  Slice(){
    for (let u of this.users){
      if (u.role=='admin'){
        this.users.splice(this.users.indexOf(u), 1)
      }
    }
  }

  delete(u: UserModel){
    this.app.deleteUser(u.userId).subscribe(x=>this.users.splice(this.users.indexOf(u), 1))
  }

}
