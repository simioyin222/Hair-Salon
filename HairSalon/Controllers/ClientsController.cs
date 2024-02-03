using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using HairSalon.Data;

namespace HairSalon.Controllers
{
    public class ClientsController : Controller
    {
        private readonly SalonDbContext _db;

        public ClientsController(SalonDbContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Client> model = _db.Clients.Include(client => client.Stylist).ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            var stylists = _db.Stylists.ToList();
            if (!stylists.Any())
            {
                ViewData["Error"] = "No stylists available. Please add a stylist first.";
                return View(new Client());
            }

            ViewBag.StylistId = new SelectList(stylists, "StylistId", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Client client)
        {
            if (ModelState.IsValid)
            {
                _db.Clients.Add(client);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            
            ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "Name", client.StylistId);
            return View(client);
        }

        public ActionResult Details(int id)
        {
            Client thisClient = _db.Clients.Include(client => client.Stylist).FirstOrDefault(client => client.ClientId == id);
            return View(thisClient);
        }

        public ActionResult Edit(int id)
        {
            var thisClient = _db.Clients.FirstOrDefault(clients => clients.ClientId == id);
            ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "Name", thisClient.StylistId);
            return View(thisClient);
        }

        [HttpPost]
        public ActionResult Edit(Client client)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(client).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "Name", client.StylistId);
            return View(client);
        }

        public ActionResult Delete(int id)
        {
            var thisClient = _db.Clients.FirstOrDefault(clients => clients.ClientId == id);
            return View(thisClient);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisClient = _db.Clients.FirstOrDefault(clients => clients.ClientId == id);
            _db.Clients.Remove(thisClient);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}