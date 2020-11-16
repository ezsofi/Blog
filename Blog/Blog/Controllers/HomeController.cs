using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}
