import { HttpClient } from '@angular/common/http';
import { Component, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.html',
  
})

@Injectable({
  providedIn: 'root'
})

export class ContactComponent {
  formData = {
    email: '',
    name: '',
    message: ''
  
  }; 

   private apiUrl = `${environment.apiUrl}/home/contact`;

    constructor(private http: HttpClient) { }

    submitForm(contact: any): Observable<any> {
        return this.http.post<any>(this.apiUrl, contact);
      
      }
 
 /*  sendMessage() {
    // Here, you can handle sending the message logic,
    // such as sending an HTTP request to a backend service.
    console.log('Message sent:', this.formData);
  } */
}