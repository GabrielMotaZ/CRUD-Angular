import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Account } from '../account';
import { LoginDataService } from '../login-data.service';
import { LoginService } from '../login/login.service';

@Component({
  selector: 'app-browse',
  templateUrl: './browse.component.html',
  styleUrls: ['./browse.component.css']
})
export class BrowseComponent implements OnInit {

  constructor(private boolLogin: LoginDataService, private route: ActivatedRoute, private router: Router, private loginService: LoginService) { }

  accounts: Account[] = [];

  ngOnInit(): void {
    if (!this.boolLogin.getLogged()) {
      this.router.navigate([''], { relativeTo: this.route });
    }
  }

  public findAllLogins(){
    this.loginService.findAllAccounts()
      .subscribe((data: Account[]) => {
        this.accounts = data; 
        console.log(this.accounts);
      });
  }
}
