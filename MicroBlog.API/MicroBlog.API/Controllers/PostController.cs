using MicroBlog.API.Models;
using MicroBlog.API.Query;
using MicroBlog.API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MicroBlog.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiVersion("1.0")]
    public class PostsController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        private readonly ILogger<PostsController> _logger;

        public PostsController(
            IPostRepository postRepository, 
            ILogger<PostsController> logger
            )
        {
            _postRepository = postRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var posts = await _postRepository.GetPosts();
            return posts.Any() ? Ok(posts) : NotFound();
        }

        [HttpGet]
        [Route("{query.id:guid}/{query.uid}")]
        public async Task<IActionResult> Get(GetPostQuery query)
        {
            var post = await _postRepository.GetPost(query.Id, query.Uid);
            return post == null ? NotFound() : Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AddPostCommand postCommand)
        {
            Post newpost = null;
            if (ModelState.IsValid)
            {
                var post = new Post
                {
                    Uid = postCommand.Uid,
                    PostContent = postCommand.PostContent,
                    ImageId = Guid.Parse(postCommand.ImageId)
                };
                newpost = await _postRepository.AddPost(post);
            }
            return newpost == null ? BadRequest("Post creation unsuccessfull") : Ok(newpost);
        }

        [HttpPut]
        [Route("{postCommand.id:guid}/{postCommand.uid}")]
        public async Task<IActionResult> Put([FromBody] UpdatePostCommand postCommand)
        {
            var id = Guid.Parse(postCommand.Id);
            var post = new Post
            {
                PostContent = postCommand.PostContent,
                ImageId = Guid.Parse(postCommand.ImageId)
            };
            var result = await _postRepository.UpdatePost(post, id, postCommand.Uid);
            return result ? Ok(postCommand) : BadRequest("Post update unsuccessfull");
        }

        [HttpDelete]
        [Route("{postCommand.id:guid}/{postCommand.uid}")]
        public async Task<IActionResult> Delete([FromBody] DeletePostCommand postCommand)
        {
            var id = Guid.Parse(postCommand.Id);
            var result = await _postRepository.DeletePost(id, postCommand.Uid);
            return result ? Ok("Post deleted.") : BadRequest("Post deletion unsuccessfull.");
        }

    }
}
