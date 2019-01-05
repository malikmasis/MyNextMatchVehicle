using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Login(IFormCollection form)
        {
            User user = new User();
            using (var db = new postgresContext())
            {
                user = db.User.AsEnumerable()
                    .Where(p=>p.Name == form["Name"]  && p.Password == form["Password"]).FirstOrDefault();
                if(user != null)
                {
                    return RedirectToAction("Index","Vehicle");
                }
            }

            return View(user);
        }
        public IActionResult Contact()
        {
            var newItem = new User();

            //using (var db = new postgresContext())
            //{
            //    // Creating a new item and saving it to the database
            //    newItem.Name = "Malik";
            //    newItem.SurName = "Chanbaz";
            //    db.User.Add(newItem);
            //    var count = db.SaveChanges();
            //}
            return View(newItem);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
