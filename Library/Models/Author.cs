using System.Collections.Generic;

namespace Library.Models
{
  public class Author
  {
    public Author()
    {
      this.JoinEntries = new HashSet<BookAuthor>();
    }
    public int AuthorId { get; set; }
    public string Name { get; set; }
    public bool Owned { get; set; }
    public virtual ICollection<BookAuthor> JoinEntries { get; }
  }
}