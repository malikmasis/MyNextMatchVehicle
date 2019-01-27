using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MNMVehicleMVC.Model;

namespace MNMVehicleMVC.Data.Models
{
    public class MockDbContext : IStoreAppContext
    {
        public DbSet<User> User { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DbSet<Vehicle> Vehicle { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public EntityEntry<T> Entry<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public DbSet<T> Set<T>() where T : class
        {
            throw new NotImplementedException();
        }
    }
}
