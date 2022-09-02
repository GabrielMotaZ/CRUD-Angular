import { Component, OnInit } from '@angular/core';
import { Account } from '../account';
import { LoginDataService } from '../login-data.service';
import { LoginService } from './login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  account: Account = {
    id: 0,
    login: '',
    password: '',
    email: ''
  };

  errorMessage: string = "";

  constructor(private loginService: LoginService) { }

  ngOnInit(): void {
  }

  public tryLogin() {
    this.errorMessage = this.loginService.tryLogin(this.account);
    console.log(this.errorMessage);
  }
}
