import { Injectable } from '@angular/core';
import { UserRegisterRequestModel, ApplicationService } from './application.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  constructor(private app: ApplicationService) { }

  public register(model: UserRegisterRequestModel):Observable<any>{
    return this.app.registerAsync(model)
  }
}
