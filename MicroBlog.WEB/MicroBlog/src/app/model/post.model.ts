export class Post {
    postContent: string;
    created_at: Date;
    updated_at: Date;
    constructor(postContent: string, created_at: Date, updated_at: Date) {
        this.postContent = postContent;
        this.created_at = created_at;
        this.updated_at = updated_at;
    }
}
