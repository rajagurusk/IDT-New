using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View("Index");
    }

    [HttpPost]
    public async Task<IActionResult> SaveCapturedImages([FromBody] List<string> base64Images)
    {
        try
        {
            if (base64Images == null || base64Images.Count == 0)
                return Json(new { success = false, message = "No images received" });

            var savedPaths = new List<string>();

            // Ensure directory exists
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "captured");
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            int count = 0;
            foreach (var base64Image in base64Images)
            {
                var base64Data = base64Image.Substring(base64Image.IndexOf(",") + 1);
                byte[] bytes = Convert.FromBase64String(base64Data);

                var fileName = $"capture_{DateTime.Now:yyyyMMdd_HHmmss}_{count}.png";
                var filePath = Path.Combine(folderPath, fileName);

                await System.IO.File.WriteAllBytesAsync(filePath, bytes);

                // URL accessible by client
                savedPaths.Add("/images/captured/" + fileName);
                count++;
            }

            // Save to session (serialize list)
            HttpContext.Session.Set("CapturedImages", JsonSerializer.SerializeToUtf8Bytes(savedPaths));

            return Json(new { success = true });
        }
        catch (Exception ex)
        {
            return Json(new { success = false, message = ex.Message });
        }
    }
}
