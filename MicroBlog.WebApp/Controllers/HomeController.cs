using MicroBlog.Common.Query;
using MicroBlog.WebApp.HttpClient;
using MicroBlog.WebApp.Models;
using MicroBlog.WebApp.SignalRHub;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MicroBlog.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPostClient _postClient;
        private readonly IPostHub _postHub;

        public HomeController(ILogger<HomeController> logger, 
            IPostClient postClient, IPostHub postHub)
        {
            _logger = logger;
            _postClient = postClient;
            _postHub = postHub;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var resposne =  await _postClient.GetPostsAsync();
            if (resposne.IsSuccessStatusCode)
            {
                var data = resposne.Content;
                return data.Any() ? View(resposne.Content) : View(nameof(Error));
            }
            return View(nameof(Error));
        }

        [HttpGet("/{id:guid}/{uid}")]
        public async Task<IActionResult> GetPost(Guid id, string uid)
        {
            var response = await _postClient.GetPostAsync(id, uid);
            if (response.IsSuccessStatusCode)
            {
                return View(response.Content);
            }
            return View(nameof(Error));
        }

        [HttpGet]
        public IActionResult AddPost()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromForm] AddPostCommand postCommand)
        {
            var response = await _postClient.AddPostAsync(postCommand);
            if (response.IsSuccessStatusCode)
            {
                await _postHub.SendPostUpdateEvent();
                return RedirectToAction(nameof(Index));
            }
            return View(nameof(Error));
        }


        [HttpPost]
        public async Task<IActionResult> UpdatePost([FromForm] UpdatePostCommand postCommand)
        {
            var response = await _postClient.UpdatePostAsync(postCommand);
            if (response.IsSuccessStatusCode)
            {
                await _postHub.SendPostUpdateEvent();
                return RedirectToAction(nameof(Index));
            }
            return View(nameof(Error));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost([FromForm] DeletePostCommand postCommand)
        {
            var response = await _postClient.DeletePostAsync(postCommand);
            if (response.IsSuccessStatusCode)
            {
                await _postHub.SendPostUpdateEvent();
                return RedirectToAction(nameof(Index));
            }
            return View(nameof(Error));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
