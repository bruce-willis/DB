using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB.Models
{
  public class Purchase
  {
    public int PurchaseID { get; set; }
    public Customer Customer { get; set; }
    public DateTime Time { get; set; }
    public decimal TotalPrice { get; set; }
    public int Amount { get; set; }
    public int CustomerID { get; set; }
    public Good Good { get; set; }
    [ForeignKey("GoodID")]
    public int GoodID { get; set; }
    [DefaultValue(false)]
    public bool Bought { get; set; }
  }
}