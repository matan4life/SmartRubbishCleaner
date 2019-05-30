import { Injectable, EventEmitter } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class HeadListenerService {

  userId: string
  onChange:EventEmitter<string> = new EventEmitter()
  change(id: string){
    this.userId = id
    this.onChange.emit(this.userId)
  }
}
