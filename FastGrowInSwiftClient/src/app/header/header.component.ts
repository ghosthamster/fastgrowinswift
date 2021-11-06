import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from '../services/account.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  fullName = '';
  loggedIn = false;
  links = [
    {route: 'choose-task', name: 'Обрати тему' },
    {route: 'statistic', name: 'Статистика' }
  ];
  activeLink = this.links[0];
  constructor(private router: Router, private accountService: AccountService) { }

  ngOnInit(): void {
    this.accountService.userChanged.subscribe(() => {
      this.fullName = this.accountService.userName;
      this.loggedIn = this.accountService.loggedIn;
    });
  }

  onLogout(): void {
    this.accountService.userId = -1;
    this.accountService.userName = '';
    this.fullName = '';
    this.accountService.loggedIn = false;
    this.loggedIn = false;
    this.router.navigateByUrl('');
  }
}
