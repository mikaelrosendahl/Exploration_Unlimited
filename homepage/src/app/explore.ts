import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-explore',
  templateUrl: './explore.html',
 
})

export class ExploreComponent {
  
  constructor(private router: Router) {
  
  }
    changePage(): void {

      this.router.navigate(['/travel']);
      
    }
}