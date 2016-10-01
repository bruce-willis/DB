using System.Collections.Generic;

namespace DB.Models
{
  public class Customer : People
  {
    public int CustomerID { get; set; }
    public decimal? Weight { get; set; }
    public decimal? Height { get; set; }
    public ICollection<Purchase> Purchases { get; set; }
  }
}