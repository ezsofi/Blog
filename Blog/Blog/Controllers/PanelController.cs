using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Database.Repository;
using Blog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [Authorize(Roles ="Admin")]
    public class PanelController : Controller
    {
        private IPostService postService;
        public PanelController(IPostService postService)
        {
            this.postService = postService;
        }

        [HttpGet("index")]
        public IActionResult Index()
        {
            var posts = postService.GetAllPost();
            return View(posts);
        }

        [HttpGet("edit")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return View(new Post());
            }
            else
            {
                var post = postService.GetPost((int)id);
                return View(post);
            }

        }

        [HttpPost("edit")]
        public async Task<IActionResult> Edit(Post post)
        {
            if (post.Id > 0)
            {
                postService.UpdatePost(post);
            }
            else
            {
                postService.AddPost(post);
            }

            if (await postService.SaveChangesAsync())
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(post);
            }

        }
        [HttpGet("remove")]
        public async Task<IActionResult> Remove(int id)
        {
            postService.RemovePost(id);
            await postService.SaveChangesAsync();

            return RedirectToAction("Index");

        }
        //[HttpGet("index")]
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
