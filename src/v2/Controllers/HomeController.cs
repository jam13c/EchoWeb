using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EchoWebV2.Models;

namespace EchoWebV2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(string text)
        {
            var podId = Environment.GetEnvironmentVariable("POD_ID");
            var who = String.IsNullOrEmpty(podId) ? "Application" : $"Pod \"{podId}\"";
            return View(new IndexModel
            {
                Who = who,
                Text = text ?? "Hello World!"
            });
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
