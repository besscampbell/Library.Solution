using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
  public class HomeController : Controller
  {
  //   private readonly LibraryContext _db;
  //   public HomeController(LibraryContext db)
  //   {
  //     _db = db;
  //   }
    public ActionResult Index()
    {
      return View();
    }
  }
}