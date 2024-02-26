import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environment/environment';
import { Post } from 'src/app/model/post.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PostService {

  constructor(private http: HttpClient) { }

  getPosts(): Observable<Post[]> {
    return this.http.get<Post[]>(`${environment.baseUrl}posts`);
  }

  getPostById(id: string, uid: string): Observable<Post> {
    return this.http.get<Post>(`${environment.baseUrl}posts/${id}/${uid}`);
  }

  createPost(post: Post) {
    return this.http.post(`${environment.baseUrl}`, post, { responseType: 'text' });
  }

  updatePost(post: Post, id: string, uid: string) {
    return this.http.put(`${environment.baseUrl}/${id}/${uid}`, post, { responseType: 'text' });
  }

  deletePost(id: string,  uid: string) {
    return this.http.delete(`${environment.baseUrl}/${id}/${uid}`, { responseType: 'text' });
  }
}
