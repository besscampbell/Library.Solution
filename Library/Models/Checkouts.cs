namespace Library.Models
{
  public class Checkouts
  {
    public int CheckoutsId { get; set; }
    public string PatronId { get; set; }
    public int CopyId { get; set; }
    public virtual Patron Patron { get; set; }
    public virtual Copy Copy { get; set; }
  }
}