using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PC1.Models;

namespace PC1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
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

    [HttpPost]
    public ActionResult Pago(string numTarj, DateTime fechaVenc, decimal montoPagar)
    {
    
    int diasAtraso = (int)(DateTime.Now - fechaVenc).TotalDays;
  
    decimal mora = montoPagar * (decimal)(diasAtraso * 0.005);
  
    decimal pFinal = montoPagar + mora;
  
    ViewBag.NumeroTarjeta = numTarj;
    ViewBag.DiasAtraso = diasAtraso;
    ViewBag.MontoPagar = montoPagar;
    ViewBag.Mora = mora;
    ViewBag.PagoFinal = pFinal;
    return View("Index");
    }
}
