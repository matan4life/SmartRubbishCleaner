import { Injectable } from '@angular/core';
import { ApplicationService, UserModel } from './application.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HeaderService {

  constructor(private app: ApplicationService) {

  }

  getUser(id: string): Observable<UserModel>{
    return this.app.getUser(id)
  }
}
