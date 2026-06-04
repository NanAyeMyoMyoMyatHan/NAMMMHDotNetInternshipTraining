using Microsoft.AspNetCore.Mvc;
using NAMMMHDotNetInternshipTraining.MVCSample.Models;
using System.Diagnostics;

namespace NAMMMHDotNetInternshipTraining.MVCSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(HomeRequestModel requestModel)
           
        {
            HomeResponseModel responseModel = new HomeResponseModel()
            {
                //pageNo = requestModel.pageNo,
                //pageSize = requestModel.pageSize
            };
                  
            return View(responseModel);
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
