using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DB.Models
{
  public abstract class People
  {
   // [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int PeopleID;
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Middlename { get; set; }
    public string Telephone { get; set; }
    public string Email { get; set; }
    public int? Age { get; set; }
  }
}
