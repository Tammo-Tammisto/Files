using Failid2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Failid2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFileClient _fileClient;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IFileClient fileClient)
        {
            _logger = logger;
            _fileClient = fileClient;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Files = _fileClient.List(FileStoreNames.Images);

            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormFile[] files)
        {
            foreach (var file in files)
            {
                _fileClient.Save(file.OpenReadStream(), file.FileName, FileStoreNames.Images);
            }

            return RedirectToAction(nameof(Index));
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