// AccountController.cs

using Microsoft.AspNetCore.Mvc;

public class AccountController : Controller
{
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string userID, string password)
    {
        // Simple placeholder: Replace this with actual authentication logic
        if (userID == "IDT" && password == "IDT@123")
        {
            // On successful login, redirect to Home page (adjust route if needed)
            return RedirectToAction("Index", "Home");
        }
        else
        {
            ViewBag.ErrorMessage = "Invalid credentials.";
            return View();
        }
    }
}
