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

namespace DB.Controllers
{
  public class GoodsController : Controller
  {
    private readonly ShopContext _context;

    public GoodsController(ShopContext context)
    {
      _context = context;
    }

    // GET: Goods
    public async Task<IActionResult> Index()
    {
      return View(await _context.Goods.ToListAsync());
    }

    // GET: Goods/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var good = await _context.Goods.SingleOrDefaultAsync(m => m.GoodID == id);
      if (good == null)
      {
        return NotFound();
      }

      return View(good);
    }

    // GET: Goods/Create
    [Authorize(Roles = "Administrator")]
    public IActionResult Create()
    {
      return View();
    }

    // POST: Goods/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("GoodID,Carbohydrate,Category,Description,Fat,Name,Price,Protein")] Good good)
    {
      if (ModelState.IsValid)
      {
        _context.Add(good);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
      }
      return View(good);
    }

    // GET: Goods/Edit/5
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var good = await _context.Goods.SingleOrDefaultAsync(m => m.GoodID == id);
      if (good == null)
      {
        return NotFound();
      }
      return View(good);
    }

    // POST: Goods/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Administrator")]

    public async Task<IActionResult> Edit(int id, [Bind("GoodID,Carbohydrate,Category,Description,Fat,Name,Price,Protein")] Good good)
    {
      if (id != good.GoodID)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(good);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!GoodExists(good.GoodID))
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
      return View(good);
    }

    // GET: Goods/Delete/5
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var good = await _context.Goods.SingleOrDefaultAsync(m => m.GoodID == id);
      if (good == null)
      {
        return NotFound();
      }

      return View(good);
    }

    // POST: Goods/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var good = await _context.Goods.SingleOrDefaultAsync(m => m.GoodID == id);
      _context.Goods.Remove(good);
      await _context.SaveChangesAsync();
      return RedirectToAction("Index");
    }

    private bool GoodExists(int id)
    {
      return _context.Goods.Any(e => e.GoodID == id);
    }
  }
}
