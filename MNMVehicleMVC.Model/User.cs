using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MNMVehicleMVC.Model
{
    public class User : BaseClass
    {
        [Required]
        public string Name { get; set; }
        public string SurName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
