import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoginDataService {

  constructor() { }

  isLogged: boolean = false;

  public setLogged(bool: boolean){
    this.isLogged = bool;
  }

  public getLogged(){
    return this.isLogged;
  }

}
