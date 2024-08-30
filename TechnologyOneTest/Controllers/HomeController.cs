using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TechnologyOneTest.Models;

namespace TechnologyOneTest.Controllers {
  public class HomeController : Controller {
    private readonly ILogger<HomeController> _logger;
        private readonly NumberLogic.Numbers _numbers;

    public HomeController(ILogger<HomeController> logger, NumberLogic.Numbers numbers) {
      _logger = logger;
            _numbers = numbers;
    }

    public IActionResult Index() {
      return View();
    }

    public IActionResult Privacy() {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpPost]
    public JsonResult ConvertNumberToString([FromBody]NumberJson data) {
            try {
                var result = _numbers.Convert(data.value, data.currency);
                return Json(new { valid = true, message = result });
            } catch (Exception ex) {

                return Json(new { valid = false, message = ex.Message });
            }
            
      
    }

  }
}
