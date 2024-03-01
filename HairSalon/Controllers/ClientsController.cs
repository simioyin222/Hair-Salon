using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using HairSalon.Data;
using Microsoft.AspNetCore.Authorization;



namespace HairSalon.Controllers
{
  public class ClientsController : Controller
  {
    private readonly SalonDbContext _db;

    public ClientsController(SalonDbContext db)
    {
      _db = db;
    }
    
    [AllowAnonymous]
    public ActionResult Index()
    {   
      List<Client> listOfAllClients = _db.Clients
                                         .Include(client => client.Stylist)
                                         .ToList();
      return View(listOfAllClients);
    }

    [Authorize]
    public ActionResult Create()
    {    
      ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "Name");
      return View();
    }
    
    [Authorize]
    [HttpPost]
    public ActionResult Create(Client entry)
    {
      if (entry.StylistId == 0)
      {
        return RedirectToAction("Create");
      }
      _db.Clients.Add(entry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    
    [AllowAnonymous]
    public ActionResult Details(int id)
    {    
      Client clientToShowDetailsOn = _db.Clients
                                        .Include(client => client.Stylist)
                                        .FirstOrDefault(client => client.ClientId == id);
      return View(clientToShowDetailsOn);
    }
    
    [Authorize]
    public ActionResult Edit(int id)
    {            
      Client targetClientToEdit = _db.Clients.FirstOrDefault(client => client.ClientId == id);
      ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "Name");
      return View(targetClientToEdit);
    }
    
    [Authorize]
    [HttpPost]
    public ActionResult Edit(Client targetClient)
    {
      _db.Clients.Update(targetClient);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    
    [Authorize]
    public ActionResult Delete(int id)
    {
      Client targetClientToDelete = _db.Clients.FirstOrDefault(client => client.ClientId == id);
      return View(targetClientToDelete);
    }
    
    [Authorize]
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Client targetClient = _db.Clients.FirstOrDefault(client => client.ClientId == id);
      _db.Clients.Remove(targetClient);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}