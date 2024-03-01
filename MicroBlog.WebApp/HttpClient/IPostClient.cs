using MicroBlog.Common.Models;
using MicroBlog.Common.Query;
using Refit;

namespace MicroBlog.WebApp.HttpClient
{
    
    public interface IPostClient
    {
        // create refit PostClient
        //[Headers("accept: application/json")]
        [Get("/Posts")]
        Task<ApiResponse<IEnumerable<Post>>> GetPostsAsync();

        //[Headers("accept: application/json")]
        [Get("/Posts/{id}/{uid}")]
        Task<ApiResponse<Post>> GetPostAsync(Guid id, string uid);

        [Headers("Content-Type: application/json;charset=utf-8")]
        [Post("/posts")]
        Task<ApiResponse<Post>> AddPostAsync([Body] AddPostCommand post);


        [Headers("Content-Type: application/json;charset=utf-8")]
        [Put("/posts")]
        Task<ApiResponse<Post>> UpdatePostAsync([Body] UpdatePostCommand post);

        [Headers("Content-Type: application/json;charset=utf-8")]
        [Delete("/posts")]
        Task<ApiResponse<Post>> DeletePostAsync([Body] DeletePostCommand post);
    }
}
