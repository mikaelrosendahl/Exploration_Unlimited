import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { UserSessionService } from '../services/user-session.service'; 

@Component({
  selector: 'app-home',
  templateUrl: './home.html'
})
export class HomeComponent implements OnInit {
  currentLanguage: string;
  isLoggedIn: boolean = false; // Lägger till inloggningsstatus
  username: string = ''; // För att visa användarnamnet

  constructor(
    private router: Router,
    private translateService: TranslateService,
    private userSessionService: UserSessionService // Injektera UserSessionService
  ) {
    // Sätt standard språk
    this.currentLanguage = this.translateService.currentLang;
    this.translateService.setDefaultLang('en');
  }

  ngOnInit(): void {
    // Kontrollera inloggningsstatus när komponenten laddas
    this.userSessionService.isLoggedIn().subscribe((response: any) => {
      this.isLoggedIn = response.IsLoggedIn;
      this.username = response.Username;
    });
  }

  switchLanguage() {
    const lang = this.currentLanguage === 'sv' ? 'en' : 'sv';
    this.translateService.use(lang);
    this.currentLanguage = lang;
  }

  changePage(): void {
    this.router.navigate(['/explore']);
  }

  showMenu: boolean = true;
  toogleList() {
    this.showMenu = !this.showMenu;
  }
}
