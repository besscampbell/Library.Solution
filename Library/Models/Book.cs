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
    public bool CheckedOut { get; set; }
    public virtual ICollection<BookAuthor> JoinEntries { get; }
  }
}