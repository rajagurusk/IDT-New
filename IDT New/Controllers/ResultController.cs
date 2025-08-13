using Microsoft.AspNetCore.Mvc;

public class ResultController : Controller
{
    // GET: /Result
    public IActionResult Index()
    {
        // Fetch data or from session/localStorage equivalent on server-side
        var resultData = new
        {
            LotNo = "L001",
            GemID = "ID123",
            Size = "5.2 mm",
            Remarks = "Sample record",
            ImageUrl = "/images/placeholder.png"
        };

        return View(resultData); // Pass data to the Result.cshtml view
    }
}
