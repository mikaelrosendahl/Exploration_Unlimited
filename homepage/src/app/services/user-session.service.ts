import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserSessionService {

  private apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }
  isLoggedIn(): Observable<any> {
    // Temporärt mockat svar för att undvika fel i frontend
    return of({ IsLoggedIn: true, Username: 'testuser' });
  }

  /* isLoggedIn(): Observable<any> {
     return this.http.get(`${this.apiUrl}/UserSessionService/IsLoggedIn`);
   }*/
}
