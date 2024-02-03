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
    }}