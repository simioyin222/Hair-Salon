using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using HairSalon.Data;

namespace HairSalon.Controllers
{
    public class StylistsController : Controller
    {
        private readonly SalonDbContext _db;

        public StylistsController(SalonDbContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            var stylists = _db.Stylists.ToList();
            return View(stylists);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Stylist stylist)
        {
            _db.Stylists.Add(stylist);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var thisStylist = _db.Stylists
                .Include(stylist => stylist.Clients)
                .FirstOrDefault(stylist => stylist.StylistId == id);

            return View(thisStylist);
        }

        public ActionResult Edit(int id)
        {
            var thisStylist = _db.Stylists.FirstOrDefault(stylists => stylists.StylistId == id);
            return View(thisStylist);
        }

        [HttpPost]
        public ActionResult Edit(Stylist stylist)
        {
            _db.Entry(stylist).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }}