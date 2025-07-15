import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-discover',
  templateUrl: './discover.html',
 
})

export class DiscoverComponent {

  constructor(private router: Router) {

  }
  changePage(): void {


    this.router.navigate(['/courses']);

  }
}