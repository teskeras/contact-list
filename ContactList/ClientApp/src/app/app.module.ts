import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ContactComponent } from './contact/contact.componentt';
import { AddComponent } from './add/add.component';
import { ContactSearchComponent } from './contact-search/contact-search.component'
import { ContactService } from './contact.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ContactComponent,
    AddComponent,
    ContactSearchComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'contact/:id', component: ContactComponent },
      { path: 'add', component: AddComponent }
    ])
  ],
  providers: [ContactService],
  bootstrap: [AppComponent]
})
export class AppModule { }
