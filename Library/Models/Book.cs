using System.Collections.Generic;

namespace Library.Models
{
  public class Book
  {
    public Book()
    {
      this.JoinEntries = new HashSet<BookAuthor>();
    }
    public int BookId { get; set; }
    public string Title { get; set; }
    public virtual Patron Patron { get; set; }
    public virtual ICollection<BookAuthor> JoinEntries { get; }
  }
}
        