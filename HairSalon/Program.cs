using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HairSalon.Data;
using HairSalon.Models;
using Microsoft.AspNetCore.Identity;

namespace HairSalon
{
  class Program
  {
    static void Main(string[] args)
    {
      WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

      builder.Services.AddControllersWithViews();

      builder.Services.AddDbContext<SalonDbContext>(
        dbContextOptions => dbContextOptions
          .UseMySql(
            builder.Configuration["ConnectionStrings:DefaultConnection"], 
            ServerVersion.AutoDetect(builder.Configuration["ConnectionStrings:DefaultConnection"])
          )
      );

      builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<SalonDbContext>();


      WebApplication app = builder.Build();



      app.UseHttpsRedirection();
      app.UseStaticFiles();
      app.UseRouting();

      app.UseAuthentication(); 
      app.UseAuthorization();

      app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
      );

      app.Run();
    }
  }
}