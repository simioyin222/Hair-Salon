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
            ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Client client)
        {
            _db.Clients.Add(client);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Client thisClient = _db.Clients.Include(client => client.Stylist).FirstOrDefault(client => client.ClientId == id);
            return View(thisClient);
        }

        public ActionResult Edit(int id)
        {
            var thisClient = _db.Clients.FirstOrDefault(clients => clients.ClientId == id);
            ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "Name");
            return View(thisClient);
        }

        [HttpPost]
        public ActionResult Edit(Client client)
        {
            _db.Entry(client).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }}