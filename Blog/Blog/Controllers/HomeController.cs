﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Database;
using Blog.Database.FileManager;
using Blog.Database.Repository;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [Route("home")]
    public class HomeController : Controller
    {
        private readonly IPostService postService;
        private readonly IFileManager fileManager;
        public HomeController(IPostService postService, IFileManager fileManager)
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
        [HttpGet("post/{id}")]
        public IActionResult GetPost(int id)
        {
            var post = postService.GetPost(id);
            return View(post);
        }

        [HttpGet("/Image/{image}")]
        public IActionResult Image(string image)
        {
            var mime = image.Substring(image.LastIndexOf('.')+1);
            return new FileStreamResult(fileManager.ImageStream(image), $"image/{mime}");
        }
    }
}
