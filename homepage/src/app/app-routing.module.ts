import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home';
import { AboutComponent } from './home/about';
import { CoursesComponent } from './home/courses';

import { PageNotFoundComponent } from './pagenotfound';
import { LoginComponent } from './home/login';
import { CreateUserComponent } from './home/create-user';
import { DiscoverComponent } from './discover';
import { ExploreComponent } from './explore';
import { TravelComponent } from './travel';
import { ContactUsComponent } from './contact-us';
import { ContactComponent } from './home/contact';
import { OWComponent } from './courses/ow-course';
import { AOComponent } from './courses/ao-course';
import { RescueComponent } from './courses/rescue-diver';
import { SpecialityComponent } from './courses/speciality-diver';
import { MSDComponent } from './courses/master-scuba-diver';
import { DMComponent } from './courses/divemaster';
import { DiaryListComponent } from './home/diary-list';
import { DiaryEntryComponent } from './home/diary-entry';
import { BlogComponent } from './home/blog';




const routes: Routes = [
  { path: '', component: HomeComponent, },
  { path: 'about', component: AboutComponent },
  { path: 'blog', component: BlogComponent },
  { path: 'courses', component: CoursesComponent },
  { path: 'contact', component: ContactComponent },
  { path: 'contact-us', component: ContactUsComponent},
  { path: 'login', component: LoginComponent },
  { path: 'create-user', component: CreateUserComponent },
  { path: 'discover', component: DiscoverComponent },
  { path: 'ow-course', component: OWComponent },
  { path: 'ao-course', component: AOComponent },
  { path: 'rescue-diver', component: RescueComponent},
  { path: 'speciality-diver', component: SpecialityComponent},
  { path: 'master-scuba-diver', component: MSDComponent},
  { path: 'divemaster', component: DMComponent },
  { path: 'explore', component: ExploreComponent },
  { path: 'travel', component: TravelComponent },
  { path: 'diary', component: DiaryListComponent }, // Lista över alla inlägg
  { path: 'diary-entry', component: DiaryEntryComponent }, // Lista över alla inlägg
  { path: 'diary/:id', component: DiaryEntryComponent }, // Visar ett specifikt inlägg
  { path: '**', component: PageNotFoundComponent },  // Wildcard route for a 404 page 
];



@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {

 }

