using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
  public class CopiesController : Controller
  {
    private readonly LibraryContext _db;

    public CopiesController(LibraryContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      ViewBag.Copies = _db.Copies.ToList();
      return View();
    }
    public ActionResult Create(int bookId)
    {
      ViewBag.BookId = bookId;
      return View();
    }
    [HttpPost]
    public ActionResult Create (Copy copy, int number, int bookId)
    {
      
      for ( var i =0; i<number; i++)
      {
        if (bookId != 0)
        {
          _db.Copies.Add(copy);
          _db.SaveChanges();
          copy.CopyId ++;
        }
      }
      return RedirectToAction("Index", "Home");
    }

    public ActionResult Edit(int id)
    {
      // ViewBag.Book = _db.Books;
      var thisCopy = _db.Copies.FirstOrDefault(copy => copy.CopyId == id);
      return View(thisCopy);
    }

    [HttpPost]
    public ActionResult Edit(Copy copy)
    {
      _db.Entry(copy).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", "Books", new { id = copy.BookId});
    }
  }
}