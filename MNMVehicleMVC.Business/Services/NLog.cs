using System;
using System.Collections.Generic;
using System.Text;

namespace MNMVehicleMVC.Business.Services
{
    public class NLog : ILogger
    {
        public void Logger()
        {
            Console.WriteLine("NLog");
        }
    }
}
