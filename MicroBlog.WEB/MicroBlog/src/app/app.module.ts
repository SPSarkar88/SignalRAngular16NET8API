import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { PostListComponent } from './component/post-list/post-list.component';
import { AppNavbarComponent } from './layout/app-navbar/app-navbar.component';
import { JumbotronComponent } from './layout/jumbotron/jumbotron.component';

@NgModule({
  declarations: [
    AppComponent,
    PostListComponent,
    AppNavbarComponent,
    JumbotronComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
