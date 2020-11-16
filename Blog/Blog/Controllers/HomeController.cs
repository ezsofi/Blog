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
            return View();
        }

        [HttpGet("post")]
        public IActionResult Post()
        {
            return View();
        }

        [HttpGet("edit")]
        public IActionResult Edit()
        {
            return View(new Post());
        }

        [HttpPost("edit")]
        public async Task<IActionResult> Edit(Post post)
        {

            postService.AddPost(post);
            if (await postService.SaveChangesAsync())
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(post);
            }

        }
    }
}
