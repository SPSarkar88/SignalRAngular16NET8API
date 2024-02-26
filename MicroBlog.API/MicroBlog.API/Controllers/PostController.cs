using MicroBlog.API.Models;
using MicroBlog.API.Query;
using MicroBlog.API.Repository;
using MicroBlog.API.SignalRHub;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroBlog.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    public class PostsController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        private readonly IPostHub _posthub;
        private readonly ILogger<PostsController> _logger;

        public PostsController(
            IPostRepository postRepository,
            ILogger<PostsController> logger,
            IPostHub postHub)
        {
            _postRepository = postRepository;
            _logger = logger;
            _posthub = postHub;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var posts = await _postRepository.GetPosts();
            return posts.Any() ? Ok(posts) : NotFound();
        }

        [HttpGet("{id:guid}/{uid}")]
        public async Task<IActionResult> Get(Guid id, string uid)
        {
            var post = await _postRepository.GetPost(id, uid);
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
                    
                    PostContent = postCommand.PostContent
                };
                newpost = await _postRepository.AddPost(post);
            }
            await _posthub.SendPostUpdateEvent();
            return newpost == null ? BadRequest("Post creation unsuccessfull") : Ok(newpost);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdatePostCommand postCommand)
        {
            var id = Guid.Parse(postCommand.Id);
            var post = new Post
            {
                Id = id,
                PostContent = postCommand.PostContent,
                Uid = postCommand.Uid
            };
            var result = await _postRepository.UpdatePost(post);
            await _posthub.SendPostUpdateEvent();
            return result ? Ok(postCommand) : BadRequest("Post update unsuccessfull");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeletePostCommand postCommand)
        {
            var id = Guid.Parse(postCommand.Id);
            var result = await _postRepository.DeletePost(id, postCommand.Uid);
            await _posthub.SendPostUpdateEvent();
            return result ? Ok("Post deleted.") : BadRequest("Post deletion unsuccessfull.");
        }

    }
}
