import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';

import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { HomeComponent } from './home/home.component';
import { HeaderComponent } from './shared/header/header.component';
import { FooterComponent } from './shared/footer/footer.component';
import { ProjectComponent } from './components/project/project.component';
import { DomainComponent } from './components/domain/domain.component';


var pages = [
  HeaderComponent,
  FooterComponent,

  HomeComponent,
  ProjectComponent,
  DomainComponent
]

@NgModule({
  declarations: [
    AppComponent,
    pages
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FontAwesomeModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
