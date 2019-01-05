using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MNMVehicleMVC.Model
{
    public class Vehicle : BaseClass
    {
        [Display(Name = "Plaka")]
        public string Plate { get; set; }
        [Display(Name = "Lakap")]
        public string Nickname { get; set; }
        [Display(Name ="Marka")]
        public string Brand { get; set; }
        [Display(Name = "Model")]
        public string Model { get; set; }
        [Display(Name = "Model Yılı")]
        public int ModelYear { get; set; } = 2000;

        [EnumDataType(typeof(VehicleType))]
        [Display(Name = "Araç Tipi")]
        public VehicleType VehicleType { get; set; }
        [Display(Name = "Renk")]
        public string Color { get; set; }
        [Display(Name = "Aktif")]
        public bool IsActive { get; set; } = true;
    }
}
