import { Component } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router'; // För eventuell omdirigering efter inloggning
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-login',
  templateUrl: './login.html',
})
export class LoginComponent {
  email: string = '';
  password: string = '';
  errorMessage: string = '';
  isLoggedIn: boolean = false;

  constructor(private authService: AuthService, private router: Router) { }

  onSubmit(): void {
  this.authService.login(this.email, this.password).subscribe(
    response => {
      console.log('Token:', response.Token);
      localStorage.setItem('jwtToken', response.Token);
      this.isLoggedIn = true;
      this.router.navigate(['/dashboard']);
    },
    (err: HttpErrorResponse) => {
      this.errorMessage = 'Login misslyckades, vänligen kontrollera dina uppgifter.';
    }
  );
}
  
  ngOnInit() {
    // Kontrollera om en token redan finns vid laddning
    const token = localStorage.getItem('jwtToken');
    if (token) {
      this.isLoggedIn = true;
    }
  }
  logout(): void {
    localStorage.removeItem('jwtToken');  // Ta bort token från localStorage
    this.isLoggedIn = false;  // Markera användaren som utloggad
  }
}
