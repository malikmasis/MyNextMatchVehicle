using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MNMVehicleMVC.API.Controllers;
using MNMVehicleMVC.Business.Services;
using MNMVehicleMVC.Data;
using MNMVehicleMVC.Model;

namespace MNMVehicleMVC.Pages.Vehicle
{
    public class IndexModel : PageModel
    {

        private ILogger _logger;
        public IndexModel(ILogger logger)
        {
            _logger = logger;
        }
        public void Logger()
        {
            _logger.Logger();
        }

        public List<Model.Vehicle> VehicleList { get; set; }
        public void OnGet()
        {
            //using (var db = new postgresContext())
            //{
            //    //Tood IVehicle


            //    VehiclesController vehicle = new VehiclesController(db);
            //    vehicle.GetVehicle();
            //}
            using (var db = new postgresContext())
            {
                VehicleList = db.Vehicle.ToList();
            }
        }

        [BindProperty]
        public Model.Vehicle Vehicle { get; set; }
        public async Task<IActionResult> OnPost()
        {
            using (var db = new postgresContext())
            {
                VehiclesController vehicle = new VehiclesController(db);
                await vehicle.PostVehicle(Vehicle);

                return RedirectToPage("/Vehicle/Index");
            }
        }
    }
}