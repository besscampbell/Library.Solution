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
  public class CopiesController : Controller
  {
    private readonly LibraryContext _db;
    private readonly UserManager<Patron> _userManager;
    public CopiesController(UserManager<Patron> userManager, LibraryContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public async Task<ActionResult> Index()
    {
        var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        Console.WriteLine(userId);
        var currentUser = await _userManager.FindByIdAsync(userId);
        Console.WriteLine(currentUser);
        var userItem = _db.Copies.Where(entry => entry.Patron.Id == currentUser.Id).ToList();
        foreach(var user in userItem)
        {
          Console.WriteLine(user);
        };
        return View(userItem);
    }
    // public ActionResult Index()
    // {
    //   return View(_db.Copies.ToList());
    // }
    public ActionResult Create(int bookId)
    {
      ViewBag.BookId = bookId;
      return View();
    }
    [HttpPost]
    public async Task<ActionResult> Create (Copy copy, int number, int bookId)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      copy.Patron = currentUser;
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

    public ActionResult Checkout(int id)
    {
      var thisCopy = _db.Copies.FirstOrDefault(copies => copies.CopyId == id);
      
      return View(thisCopy); 
    }
    [HttpPost]
    public async Task<ActionResult> Checkout(Copy copy)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      if (userId != "")
      {
        _db.Checkouts.Add(new Checkouts() {PatronId = userId, CopyId = copy.CopyId});
      }
      _db.SaveChanges();
      return RedirectToAction("Index", "Home");
    }
  }
}