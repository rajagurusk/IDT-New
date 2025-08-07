using Microsoft.AspNetCore.Mvc;

public class AccountController : Controller
{
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    // (Optional: Add a [HttpPost] Login method later for actual authentication)
}
