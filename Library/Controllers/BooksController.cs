using Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Library.Controllers
{
  [Authorize]
  public class BooksController : Controller
  {
    private readonly LibraryContext _db;
    private readonly UserManager<Patron> _userManager;
    public BooksController(UserManager<Patron> userManager, LibraryContext db)
    {
      _userManager = userManager;
      _db = db;
    }
    public async Task<ActionResult> Index()
    {
        var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var currentUser = await _userManager.FindByIdAsync(userId);
        var userItems = _db.Books.Where(entry => entry.Patron.Id == currentUser.Id).ToList();
        return View(userItems);
    }

    // public async Task<IActionResult> Index(string searchString)
    // {
    //   var books = from b in _db.Books
    //     select b;
    //   if (!String.IsNullOrEmpty(searchString))
    //   {
    //     books = books.Where(s => s.Title.Contains(searchString));
    //   }
    //   return View(await books.ToAsyncEnumerable().ToList());
    // }

    public ActionResult Create()
    {
      ViewBag.Authors = _db.Authors.ToList();
      return View();
    }
    [HttpPost]
    public async Task<ActionResult> Create (Book book, List<int> authors)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      book.Patron = currentUser;
      _db.Books.Add(book);
      if (authors.Count != 0)
      {
        foreach( int author in authors)
        {
          _db.BookAuthor.Add(new BookAuthor() {AuthorId = author, BookId = book.BookId});
        }
      }
      _db.SaveChanges();
      return RedirectToAction("Index", "Home");
    }

    public ActionResult Details(int id)
    {
      ViewBag.Copies = _db.Copies.ToList();
      var thisBook = _db.Books
        // .Include(book => book.JoinEntries)
        // .ThenInclude(join => join.Author)
        .FirstOrDefault(book => book.BookId == id);
      return View(thisBook);
    }

    public ActionResult Edit(int id)
    {
      var thisBook = _db.Books.FirstOrDefault(book => book.BookId == id);
      return View(thisBook);
    }

    [HttpPost]
    public ActionResult Edit(Book book)
    {
      _db.Entry(book).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddAuthor(int id)
    {
      var thisBook = _db.Books.FirstOrDefault(books => books.BookId == id);
      ViewBag.Authors = _db.Authors.ToList();
      return View(thisBook); 
    }

    [HttpPost]
    public ActionResult AddAuthor(Book book, List<int> authors)
    {
      if (authors.Count != 0)
      {
        foreach( int author in authors)
        {
          _db.BookAuthor.Add(new BookAuthor() {AuthorId = author, BookId = book.BookId});
        }
      }
      _db.SaveChanges();
      return RedirectToAction("Index", "Home");

    }
    public ActionResult Delete(int id)
    {
      var thisBook = _db.Books.FirstOrDefault(book => book.BookId == id);
      return View(thisBook);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisBook = _db.Books.FirstOrDefault(book => book.BookId == id);
      _db.Books.Remove(thisBook);
      _db.SaveChanges();
      return RedirectToAction("Index", "Home");
    }
  }
}