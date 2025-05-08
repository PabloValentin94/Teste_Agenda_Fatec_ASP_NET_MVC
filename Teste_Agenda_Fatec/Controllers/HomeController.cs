using Microsoft.AspNetCore.Mvc;

using Teste_Agenda_Fatec.Models;

using System.Diagnostics;

namespace Teste_Agenda_Fatec.Controllers;

public class HomeController : Controller
{

    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {

        _logger = logger;

    }

    /*
     
        /Home ou /Home/Index

    */

    public IActionResult Index()
    {

        return View();

    }

    /*
     
        /Home/Equipe

    */

    public IActionResult Equipe()
    {

        return View();

    }

    /*
     
        /Home/Ajuda

    */

    public IActionResult Ajuda()
    {

        return View();

    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {

        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    
    }

}