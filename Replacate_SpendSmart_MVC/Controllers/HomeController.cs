using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
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
        //Putting all the data in a list and displaying it on Expenses.cshtml
        var alldata = _context.ExpensesData.ToList();
        return View(alldata);
    }
    public IActionResult CreateEditExpenses(int? id)
    {
        if (id != null)
        {
            var expenseInDb = _context.ExpensesData.FirstOrDefault(firstItem => firstItem.Id == id);
            return View(expenseInDb);
        }

        return View();
    }
    public IActionResult CreateEditExpensesForm(ExpensesModel expensesData)
    {
        if (expensesData.Id == 0)
        {
            _context.ExpensesData.Add(expensesData);
        }
        else
        {
            _context.ExpensesData.Update(expensesData);
        }

        _context.SaveChanges();

        return RedirectToAction("Expenses");
    }
    public IActionResult DeleteExpenses(int id)
    {
        //Selecting the item with the same Id as the id parameter inside the Database and deleting it.
        var expenseInDb = _context.ExpensesData.FirstOrDefault(firstItem => firstItem.Id == id);
        _context.ExpensesData.Remove(expenseInDb);
        _context.SaveChanges();

        return RedirectToAction("Expenses");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
