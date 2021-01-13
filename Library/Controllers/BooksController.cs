using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
  public class BooksController : Controller
  {
    private readonly LibraryContext _db;
    public BooksController(LibraryContext db)
    {
      _db = db;
    }
    public async Task<IActionResult> Index(string searchString)
    {
      var books = from b in _db.Books
        select b;
      if (!String.IsNullOrEmpty(searchString))
      {
        books = books.Where(s => s.Title.Contains(searchString));
      }
      return View(await books.ToAsyncEnumerable().ToList());
    }

    public ActionResult Create()
    {
      ViewBag.Authors = _db.Authors.ToList();
      return View();
    }
    [HttpPost]
    public ActionResult Create (Book book, List<int> authors)
    {
      _db.Books.Add(book);
      try 
      {
        if (authors.Count != 0)
        {
          foreach( int author in authors)
          {
            _db.BookAuthor.Add(new BookAuthor() {AuthorId = author, BookId = book.BookId});
          }
        }
      } 
      catch
      {
        ViewBag.error = "Please Select An Author";
        return RedirectToAction("Create");
      }
      _db.SaveChanges();
      return RedirectToAction("Index", "Home");
    }

    public ActionResult Details(int id)
    {
      ViewBag.Copies = _db.Copies.ToList();
      var thisBook = _db.Books
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