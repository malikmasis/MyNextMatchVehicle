using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MNMVehicleMVC.API.Controllers;
using MNMVehicleMVC.Data;
using MNMVehicleMVC.Model;
using MNMVehicleMVC.Models;

namespace MNMVehicleMVC.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Login()
        {
            User user = new User();
            return View(user);
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            using (var db = new postgresContext())
            {
                if (ModelState.IsValid)
                {
                    user = db.User.AsEnumerable()
                    .Where(p => p.Name == user.Name && p.Password == user.Password).FirstOrDefault();
                    if (user != null)
                    {
                        return RedirectToAction("Index", "Vehicle");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Bilgilerinizi Kontrol Edin.");
                    return View(user);
                }
            }

            return View(user);
        }
        public IActionResult Contact()
        {
            var user = new User();

            using (var db = new postgresContext())
            {
                user.Name = "Malik";
                user.SurName = "Chanbaz";
                db.User.Add(user);
                var count = db.SaveChanges();
            }
            return View(user);
        }

        public IEnumerable<Vehicle> VehicleList { get; set; }
        public async Task<IActionResult> About()
        {
            using (var db = new postgresContext())
            {
                //Tood IVehicle
                VehiclesController vehicle = new VehiclesController(db);
                VehicleList = await vehicle.GetVehicle();
            }
            return View(VehicleList);
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
