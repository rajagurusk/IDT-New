using Microsoft.AspNetCore.Mvc;

namespace IDT_New.Controllers
{
    public class SettingsController : Controller
    {
        // GET: /Settings/
        public IActionResult Index()
        {
            return View();
        }
    }
}
