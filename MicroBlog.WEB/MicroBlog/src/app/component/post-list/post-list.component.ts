import { Component, OnInit } from '@angular/core';
import { PostService } from 'src/app/service/post-service.service';
import { Router } from '@angular/router';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr'
import { Post } from 'src/app/model/post.model';
import { environment } from 'src/environment/environment';

@Component({
  selector: 'app-post-list',
  templateUrl: './post-list.component.html',
  styleUrls: ['./post-list.component.css']
})
export class PostListComponent implements OnInit{
  posts: Post[] = []
  private hubUrl: string = `${environment.baseUrl}posthub`

  constructor(private postService: PostService, 
    private router: Router, 
    private hubConn: HubConnection) {

  }

  ngOnInit(): void {
    this.getPosts();

    this.hubConn = new HubConnectionBuilder()
                      .withUrl(this.hubUrl)
                      .build()

    this.hubConn.start()
    .then(() => {
      console.log('Connection started')
    })
    .catch(err => console.log('Error while starting connection: ' + err))

    this.hubConn.on('PostAdded', (post: Post) => {
      this.posts.push(post)
    })
  }

  getPosts() {
    this.postService.getPosts().subscribe({
      next: (data) => {
        this.posts = data
      },
      error: (error) => {
        console.error(error)
      }
    })
  }

  toEditPage(post: Post) {
    this.router.navigate(['/post/edit', post.id, post.uid])
  }

  toDeletePage(post: Post) {
    this.router.navigate(['/post/delete', post.id, post.uid])
  }
  
}
