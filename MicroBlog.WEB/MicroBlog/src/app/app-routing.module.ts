import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {PostListComponent} from "./component/post-list/post-list.component";
import {JumbotronComponent} from "./layout/jumbotron/jumbotron.component";

const routes: Routes = [
  { path: 'posts', component: PostListComponent },
  { path: 'home', component: JumbotronComponent },
  // { path: 'post/:id/:uid', component: PostComponent  },
  // { path: 'post-create', component: PostCreateComponent, },
  // { path: 'post-update', component: PostUpdateComponent, },
   { path: '',   redirectTo: '/home', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
