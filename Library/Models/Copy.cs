using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Library.Models
{
  public class Copy
  {
    public Copy()
    {
      this.Checkouts = new HashSet<Checkouts>();
    }
    public int CopyId { get; set; }
    public int BookId { get; set; }
    public virtual Patron Patron { get; set; }
    public virtual Book Book { get; set; }
    [DisplayName("Due Date")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM-dd-yyyy}")]
    public DateTime DueDate { get; set; }
    public bool CheckedOut { get; set; }
    public virtual ICollection<Checkouts> Checkouts { get; }
  }
}