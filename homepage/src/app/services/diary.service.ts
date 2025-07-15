import { Injectable } from '@angular/core'; 
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { DiaryEntry  } from '../models/diary-entry-model';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DiaryService {
  
  // Backend API URL
  private apiUrl = `${environment.apiUrl}/diary`;

  constructor(private http: HttpClient) {}

  getApiUrl(): string {
    return this.apiUrl;
  }
  // Hämta alla inlägg (GET)
  getAllEntries(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl); // GET request till backend API för att hämta alla dagboksinlägg
  }
 // Hämta ett specifikt inlägg (GET baserat på ID)
  getEntryById(id: number): Observable<DiaryEntry> {
    return this.http.get<DiaryEntry>(`${this.apiUrl}/${id}`);  // Hämta inlägg med ID
  }
  // Skapa ett nytt inlägg (POST)
  createEntry(newEntry: { title: string, content: string }): Observable<any> {
    return this.http.post<any>(this.apiUrl, newEntry); // POST request för att skicka ett nytt dagboksinlägg
  }
}

