using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [Route("home")]
    public class HomeController : Controller
    {
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
        public IActionResult Edit(Post post)
        {
            return RedirectToAction("Index");
        }
    }
}
