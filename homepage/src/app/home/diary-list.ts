import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DiaryService } from '../services/diary.service';

@Component({
  selector: 'app-diary-list',
  templateUrl: './diary-list.html',
})
export class DiaryListComponent implements OnInit {

  diaryEntries: any[] = [];

  constructor(private diaryService: DiaryService, private router: Router) { }

  // Hämta alla inlägg från API:et vid sidladdning
  ngOnInit() {
    this.loadDiaryEntries();
  }

  loadDiaryEntries() {
    console.log('Hämtar dagboksinlägg...');
    this.diaryService.getAllEntries().subscribe(
      (data: any[]) => {
        // Sortera så att högst ID kommer först
        this.diaryEntries = data.sort((a, b) => b.id - a.id);
        console.log('Sorterade inlägg:', this.diaryEntries);
      },
      error => {
        console.error('Fel vid hämtning av data:', error);
      }
    );
  }

  trackById(index: number, entry: any): number {
    return entry.id;
  }
  // Metod för att navigera till specifikt inlägg
  viewEntry(entry: { id: number, title: string, content: string }) {
    if (!entry || !entry.id) {
      console.error('Ogiltigt entry eller saknad ID:', entry);
      return;
    }
    this.router.navigate(['/diary', entry.id]);
  }
}
