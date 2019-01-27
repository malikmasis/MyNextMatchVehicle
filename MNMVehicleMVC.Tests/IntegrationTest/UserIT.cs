using Microsoft.VisualStudio.TestTools.UnitTesting;
using MNMVehicleMVC.Data;
using MNMVehicleMVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MNMVehicleMVC.Tests.IntegrationTest
{
    [TestClass]
    public class UserIT
    {
        [TestMethod]
        public void Login()
        {
            using (var db = new postgresContext())
            {
                User user = db.User.AsEnumerable()
                .Where(p => p.Name == "malik" && p.Password == "chanbaz").FirstOrDefault();
                Assert.AreNotEqual(user,null);
            }
        }

        [TestMethod]
        public void Contact()
        {
            
        }

        [TestMethod]
        public void About()
        {
        }
    }
}
