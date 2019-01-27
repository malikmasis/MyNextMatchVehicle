using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MNMVehicleMVC.Model;
using System;

namespace MNMVehicleMVC.Data
{
    public interface IStoreAppContext : IDisposable
    {
        DbSet<T> Set<T>() where T : class;
        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();

        DbSet<User> User { get; set; }
        DbSet<Vehicle> Vehicle { get; set; }
    }
}