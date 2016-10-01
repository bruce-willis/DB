using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DB.Data;
using DB.Models;

namespace DB
{
  public static class DbInitializer
  {
    public static void Initialize(ShopContext context)
    {
      context.Database.EnsureCreated();

      // Look for any students.
      if (context.Purchases.Any())
      {
        return; // DB has been seeded
      }
      //var goods = new Good[]
      //{
      //  new Good(), 
      //}
      context.SaveChanges();
    }
  }
}