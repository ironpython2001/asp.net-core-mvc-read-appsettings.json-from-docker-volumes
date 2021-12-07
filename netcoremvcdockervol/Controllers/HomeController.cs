using Microsoft.AspNetCore.Mvc;
using netcoremvcdockervol.Models;
using System.Diagnostics;
using System.Text;

namespace netcoremvcdockervol.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration; 

        public HomeController(ILogger<HomeController> logger,IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            var sb = new StringBuilder();
            var path = Path.Combine("/usr/share/aspnetcoredockervolume");
            var files = Directory.GetFiles(path);
            foreach(var file in files)
            {
                sb.Append(file.ToString()+"<br/>");
            }
            ViewData["sb"] = sb.ToString();
            ViewData["sampleconfig"] = _configuration["sampleconfig"].ToString();
            return View();
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