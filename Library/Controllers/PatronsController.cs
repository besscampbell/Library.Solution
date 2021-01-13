using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Library.ViewModels;

namespace Library.Controllers
{
  public class PatronsController : Controller
  {
    private readonly LibraryContext _db;
    private readonly UserManager<Patron> _userManager;
    private readonly SignInManager<Patron> _signInManager;
    public PatronsController (UserManager<Patron> userManager, SignInManager<Patron> signInManager, LibraryContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }

        public ActionResult Index()
        {
            return View(_db.Patrons.ToList());
        }

        

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create (Patron patron)
        {
            _db.Patrons.Add(patron);
            _db.SaveChanges();
            return RedirectToAction("Details", new { id = patron.Id});
        }

        public ActionResult Details(string id)
        {
            var thisPatron = _db.Patrons.FirstOrDefault(patron => patron.Id == id);
            return View(thisPatron);
        }

        // public ActionResult Edit(string id)
        // {
        //     var thisPatron = _db.Patrons.FirstOrDefault(patron => patron.Id == id);
        //     return View(thisPatron);
        // }

        // [HttpPost]
        // public ActionResult Edit(Patron patron)
        // {
        //     Console.WriteLine(patron.Name);
        //     Console.WriteLine(patron.Id);
        //     // _db.Entry(patron).State = EntityState.Modified;
        //     _db.SaveChanges();
        //     return RedirectToAction("Details", new { id = patron.Id});
        // }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register (RegisterViewModel model)
        {
            var user = new Patron { UserName = model.Email };
            IdentityResult result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public async Task<ActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
  }
}
