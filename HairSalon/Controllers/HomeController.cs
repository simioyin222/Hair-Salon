﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using HairSalon.Data;


namespace HairSalon.Controllers
{
  public class HomeController : Controller
  {
    private readonly SalonDbContext _db;

    public HomeController(SalonDbContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      return View();
    }
  }
}