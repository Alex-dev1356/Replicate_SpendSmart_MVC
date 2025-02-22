using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Replacate_SpendSmart_MVC.Models;

namespace Replacate_SpendSmart_MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ExpensesModelDatabase _context; 

    //Injecting the DB Context
    public HomeController(ILogger<HomeController> logger, ExpensesModelDatabase context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult Expenses()
    {
        return View();
    }
    public IActionResult CreateEditExpenses()
    {
        return View();
    }
    public IActionResult CreateEditExpensesForm(ExpensesModel expensesData)
    {
        _context.ExpensesData.Add(expensesData);
        _context.SaveChanges();

        return RedirectToAction("Expenses");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
