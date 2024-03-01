using MicroBlog.WebApp.HttpClient;
using MicroBlog.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MicroBlog.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPostClient _postClient;

        public HomeController(ILogger<HomeController> logger, IPostClient postClient)
        {
            _logger = logger;
            _postClient = postClient;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var posts =  await _postClient.GetPostsAsync();
            return View(posts);
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
