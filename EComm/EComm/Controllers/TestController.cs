using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EComm.Controllers
{
    public class TestController : Controller
    {
        [HttpGet("test")]
        public IActionResult Index()
        {
            var os = Environment.OSVersion.Platform.ToString();

            return Content(os);
        }
    }
}