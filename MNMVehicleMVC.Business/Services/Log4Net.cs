using System;
using System.Collections.Generic;
using System.Text;

namespace MNMVehicleMVC.Business.Services
{
    public class Log4Net : ILogger
    {
        public void Logger()
        {
            Console.WriteLine("Log4Net");
        }
    }
}
