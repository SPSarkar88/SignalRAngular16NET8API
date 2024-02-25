import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { PostListComponent } from './component/post-list/post-list.component';
import { AppNavbarComponent } from './layout/app-navbar/app-navbar.component';

@NgModule({
  declarations: [
    AppComponent,
    PostListComponent,
    AppNavbarComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
