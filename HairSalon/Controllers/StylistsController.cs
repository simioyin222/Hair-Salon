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
    }}