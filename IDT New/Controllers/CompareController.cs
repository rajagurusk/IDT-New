using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Text.Json;

public class CompareController : Controller
{
    public IActionResult Index()
    {
        List<string> images = new();

        if (HttpContext.Session.TryGetValue("CapturedImages", out var data))
        {
            images = JsonSerializer.Deserialize<List<string>>(data) ?? new List<string>();
        }

        ViewData["CapturedImages"] = images;
        return View("Index");
    }
}
