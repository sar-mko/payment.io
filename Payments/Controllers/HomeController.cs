using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Payments.Models;

namespace Payments.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    
    private readonly PaymentsDbContext _context;
    

    // gets implemented by the dependency _ system
    public HomeController(ILogger<HomeController> logger, PaymentsDbContext context)
    {
        _logger = logger;
        _context = context;
    }
// go to that viewpoint
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
//render the view with the same name of the IActionResult
    public IActionResult Purchases()
    //want to show all purchases made, now we have a set up context
    {
        var allPurchases = _context.Purchases.ToList();
        var totalPurchases = allPurchases.Sum(item => item.Amount);
        ViewBag.Purchases = totalPurchases;
        
        return View(allPurchases);
    }
    
    public IActionResult AddPurchases(int? id)
    {
        if (id != null)
        {
            // load purch by id
            var purchase = _context.Purchases.SingleOrDefault(item => item.Id == id);
            return View(purchase);
        }
        return View();
    }
/*
    public IActionResult CreateEditPurchase(int? id)
    {
       
        // if doesnt exist, create and return
        return View();
    }
    */
    public IActionResult DeletePurchase(int id)
    {
        //return the purchase we are looking for
        var purchase = _context.Purchases.SingleOrDefault(item => item.Id == id);
        _context.Purchases.Remove(purchase);
        _context.SaveChanges();
        return RedirectToAction("Purchases");
    }
    public IActionResult CreatePurchaseForm(Purchase model)
    {
        if (model.Id == 0)
        {
            //create
            _context.Purchases.Add(model);
        }
        else
        {
            //edit
            _context.Purchases.Update(model);
        }
        
        // make something, context: think database
        //calling add is not enough, u need to save ur changes
        _context.SaveChanges();
        
        return RedirectToAction("Purchases");
    }
    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}