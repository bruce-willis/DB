using System.Collections.Generic;

namespace DB.Models
{
  public class Dealer
  {
    public int DealerID { get; set; }
    public string Promocode { get; set; }
    public ICollection<Purchase> Sold { get; set; } 
  }
}