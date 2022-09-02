import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Account } from '../account';
import { ActivatedRoute, Router} from '@angular/router';
import { LoginDataService } from '../login-data.service';
import { Observable } from 'rxjs/internal/Observable';
import { map } from 'rxjs/internal/operators/map';

interface ServerData {
  accounts: Account[];
}

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http: HttpClient, private route: ActivatedRoute, private router: Router, private loginBool: LoginDataService) { }

  public tryLogin(account: Account) {

    this.http.post<any>('https://localhost:7197/Login', { login: account.login, password: account.password })
    .subscribe({
      next: data => {
        account.id = data.id;
        account.email = data.email;
        this.loginBool.setLogged(true);
        this.router.navigate(['browse'], { relativeTo: this.route })
        console.error("Logged in!");
      },
      error: error => {
        this.loginBool.setLogged(false);
          console.error("Couldn't login!", error.status);
        }
      })
    if (this.loginBool.getLogged()) {
      return "Openning browser!";
    }
    else {
      return "Couldn't login!";
    }
  }

  findAllAccounts() {
    return this.http.get<Account[]>('https://localhost:7197/getLogins');
  }
}
