using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using HairSalon.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;



namespace HairSalon.Controllers
{
  [Authorize]
  public class StylistsController : Controller
  {
    private readonly SalonDbContext _db;

    public StylistsController(SalonDbContext db)
    {
      _db = db;
    }
    
    [AllowAnonymous]
    public ActionResult Index()
    { 
      List<Stylist> listOfStylists = _db.Stylists.ToList();
      return View(listOfStylists);
    }

    
    public ActionResult Create()
    {                 
      return View();
    }
    
    
    [HttpPost]
    public ActionResult Create(Stylist entry)
    {
      _db.Stylists.Add(entry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    
    [AllowAnonymous]
    public ActionResult Details(int id)
    {               
      Stylist targetStylist = _db.Stylists
                                 .Include(stylist => stylist.Clients)
                                 .FirstOrDefault(stylist => stylist.StylistId == id);
      return View(targetStylist);
    }

    
    public ActionResult Edit(int id)
    {                 
      Stylist targetStylist = _db.Stylists
                                  .FirstOrDefault(stylist => stylist.StylistId == id);
      return View(targetStylist);
    }
    
    
    [HttpPost]
    public ActionResult Edit(Stylist editedEntry)
    {
      _db.Stylists.Update(editedEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    
    
    public ActionResult Delete(int id)
    {               
      Stylist targetStylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
      return View(targetStylist);
    }

    
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Stylist targetStylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
      _db.Stylists.Remove(targetStylist);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}