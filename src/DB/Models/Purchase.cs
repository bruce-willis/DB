using System;
using System.Collections.Generic;

namespace DB.Models
{
  public class Purchase
  {
    public int PurchaseID { get; set; }
    public DateTime Time { get; set; }
    public decimal TotalPrice { get; set; }
    public int Amount { get; set; }
    public ICollection<Good> Goods { get; set; }
  }
}