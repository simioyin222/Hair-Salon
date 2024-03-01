using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace HairSalon.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      return View();
    }
  }
}