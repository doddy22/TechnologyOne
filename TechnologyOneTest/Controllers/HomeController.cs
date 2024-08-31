using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TechnologyOneTest.Models;

namespace TechnologyOneTest.Controllers {
  public class HomeController : Controller {
    private readonly ILogger<HomeController> _logger;
        private readonly NumberLogic.NumbersToWords _numbersToWords;

    public HomeController(ILogger<HomeController> logger, NumberLogic.NumbersToWords numbersToWords) {
      _logger = logger;
      _numbersToWords = numbersToWords;
    }

    public IActionResult Index() {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    /// <summary>
    /// Endpoint to get the words for a Number
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    [HttpPost]
    public JsonResult ConvertNumberToString([FromBody]NumberJson data) {
        try {
            var result = _numbersToWords.Convert(data.value, data.currency);
            return Json(new { valid = true, message = result });
        } catch (Exception ex) {

            return Json(new { valid = false, message = ex.Message });
        }
            
      
    }

  }
}
