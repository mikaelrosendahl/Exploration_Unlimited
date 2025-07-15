import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home';
import { AboutComponent } from './home/about';
import { BlogComponent } from './home/blog';
import { CoursesComponent } from './home/courses';
import { PageNotFoundComponent } from './pagenotfound';
import { FooterComponent } from './footer';
import { LoginComponent } from './home/login';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { TranslationLoaderService } from './services/translation-loader.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { ExploreComponent } from './explore';
import { DiscoverComponent } from './discover';
import { TravelComponent } from './travel';
import { AboutUsComponent } from './about-us';
import { CaroselComponent } from './carosel';
import { ContactComponent } from './home/contact';
import { ReactiveFormsModule } from '@angular/forms';
import { CreateUserComponent } from './home/create-user';
import { ContactUsComponent } from './contact-us';
import { OurCoursesComponent } from './our-courses';
import { OWComponent } from './courses/ow-course';
import { AOComponent } from './courses/ao-course';
import { RescueComponent } from './courses/rescue-diver';
import { SpecialityComponent } from './courses/speciality-diver';
import { MSDComponent } from './courses/master-scuba-diver';
import { DiaryListComponent } from './home/diary-list';
import { DiaryEntryComponent } from './home/diary-entry';






@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AboutComponent,
    BlogComponent,
    CoursesComponent,
    PageNotFoundComponent,
    FooterComponent,
    LoginComponent,
    ExploreComponent,
    DiscoverComponent,
    TravelComponent,
    AboutUsComponent,
    CaroselComponent,
    ContactComponent,
    CreateUserComponent,
    ContactUsComponent,
    OurCoursesComponent,
    OWComponent,
    AOComponent,
    RescueComponent,
    SpecialityComponent,
    MSDComponent,
    DiaryListComponent,
    DiaryEntryComponent,
   
   
   
  

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule, 
    HttpClientModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useClass: TranslationLoaderService,
        deps: [HttpClient]
      }
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
