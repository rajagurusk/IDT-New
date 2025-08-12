using Microsoft.AspNetCore.Mvc;

namespace IDT_New.Controllers
{
    public class SettingsController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormCollection form)
        {
            // Handle saving settings if needed
            ViewBag.Message = "Settings saved!";
            return View();
        }
    }
}