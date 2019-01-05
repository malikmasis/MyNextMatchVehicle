using System;

namespace MNMVehicleMVC.Model
{
    public class BaseClass : IEntity
    {
        public long Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; }
    }
}