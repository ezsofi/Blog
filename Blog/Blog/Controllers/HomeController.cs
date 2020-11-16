using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Database;
using Blog.Database.Repository;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [Route("home")]
    public class HomeController : Controller
    {
        private IPostService postService;
        public HomeController(IPostService postService)
        {
            this.postService = postService;
        }
        
        [HttpGet("index")]
        public IActionResult Index()
        {
            var posts = postService.GetAllPost();
            return View(posts);
        }
    }
}
