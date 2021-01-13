using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Library.Models
{
  public class Patron : IdentityUser
  {
    public Patron()
  {
    this.Checkouts = new HashSet<Checkouts>();
  }
  public int PatronId { get; set; }
  public string Name { get; set; }
  public virtual ICollection<Checkouts> Checkouts { get; set; }
  }
}
