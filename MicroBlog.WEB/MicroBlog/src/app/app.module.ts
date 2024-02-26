import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { PostListComponent } from './component/post-list/post-list.component';
import { AppNavbarComponent } from './layout/app-navbar/app-navbar.component';
import { JumbotronComponent } from './layout/jumbotron/jumbotron.component';
import { AppRoutingModule } from './app-routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from "@angular/common/http";
import { PostService } from './service/post-service.service';


@NgModule({
  declarations: [
    AppComponent,
    PostListComponent,
    AppNavbarComponent,
    JumbotronComponent
  ],
    imports: [
        BrowserModule,
      AppRoutingModule,
      BrowserModule,
      HttpClientModule,
      ReactiveFormsModule,
    ],
  providers: [
    PostService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
