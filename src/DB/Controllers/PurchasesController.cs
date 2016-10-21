using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DB.Data;
using DB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace DB.Controllers
{
  public class PurchasesController : Controller
  {
    private readonly ShopContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public PurchasesController(ShopContext context, UserManager<ApplicationUser> userManager)
    {
      _context = context;
      _userManager = userManager;
    }

    // GET: Purchases
    [Authorize]
    public async Task<IActionResult> Index()
    {
      var currentUser = await _userManager.GetUserAsync(User);
      var currentID = currentUser.CustomerID;
      var currentCustomer =  new Customer()
      {
        CustomerID = currentID.Value
      };
      // var cart = await  _context.Customers.
      var purchases = (from s in _context.Purchases
        where s.CustomerID == currentID
        select s).ToList(); ;/*SingleOrDefaultAsync(m => m.CustomerID == currentID.Value);*/
     // Customer customers = _context.Customers.Where(s => s.CustomerID == currentID.Value).FirstOrDefault<Customer>();
      try
      {
        return View(purchases.ToList());
      }
      catch (ArgumentNullException)
      {
        return NotFound();
      }
      
      
    }

    // GET: Purchases/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var purchase = await _context.Purchases.SingleOrDefaultAsync(m => m.PurchaseID == id);
      if (purchase == null)
      {
        return NotFound();
      }

      return View(purchase);
    }

    // GET: Purchases/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: Purchases/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("PurchaseID,Amount,Time,TotalPrice")] Purchase purchase)
    {
      if (ModelState.IsValid)
      {
        _context.Add(purchase);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
      }
      return View(purchase);
    }

    // GET: Purchases/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var purchase = await _context.Purchases.SingleOrDefaultAsync(m => m.PurchaseID == id);
      if (purchase == null)
      {
        return NotFound();
      }
      return View(purchase);
    }

    // POST: Purchases/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("PurchaseID,Amount,Time,TotalPrice")] Purchase purchase)
    {
      if (id != purchase.PurchaseID)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(purchase);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!PurchaseExists(purchase.PurchaseID))
          {
            return NotFound();
          }
          else
          {
            throw;
          }
        }
        return RedirectToAction("Index");
      }
      return View(purchase);
    }

    // GET: Purchases/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var purchase = await _context.Purchases.SingleOrDefaultAsync(m => m.PurchaseID == id);
      if (purchase == null)
      {
        return NotFound();
      }

      return View(purchase);
    }

    // POST: Purchases/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var purchase = await _context.Purchases.SingleOrDefaultAsync(m => m.PurchaseID == id);
      _context.Purchases.Remove(purchase);
      await _context.SaveChangesAsync();
      return RedirectToAction("Index");
    }

    private bool PurchaseExists(int id)
    {
      return _context.Purchases.Any(e => e.PurchaseID == id);
    }
  }
}
