using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Database.FileManager;
using Blog.Database.Repository;
using Blog.Models;
using Blog.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [Authorize(Roles ="Admin")]
    public class PanelController : Controller
    {
        private readonly IPostService postService;
        private readonly IFileManager fileManager;
        public PanelController(IPostService postService, IFileManager fileManager)
        {
            this.postService = postService;
            this.fileManager = fileManager;
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
                return View(new PostViewModel());
            }
            else
            {
                var post = postService.GetPost((int)id);
                return View(new PostViewModel
                {
                    Id = post.Id,
                    Title = post.Title,
                    Body = post.Body
                }) ;
            }

        }

        [HttpPost("edit")]
        public async Task<IActionResult> Edit(PostViewModel vm)
        {
            var post = new Post
            {
                Id = vm.Id,
                Title = vm.Title,
                Body = vm.Body,
                Image = await fileManager.SaveImage(vm.Image)  // handle image
            };
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
