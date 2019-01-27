using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MNMVehicleMVC.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MNMVehicleMVC.Data.Models
{
    public class TestDbSet<T> : DbSet<T>, IQueryable, IEnumerable<T>,IStoreAppContext
        where T : class
    {
        ObservableCollection<T> _data;
        IQueryable _query;

        public TestDbSet()
        {
            _data = new ObservableCollection<T>();
            _query = _data.AsQueryable();
        }

        public override EntityEntry<T> Add(T item)
        {
            _data.Add(item);
            return item as EntityEntry<T>;
        }

        public override EntityEntry<T> Remove(T item)
        {
            _data.Remove(item);
            return null;
        }

        public override EntityEntry<T> Attach(T item)
        {
            _data.Add(item);
            return null;
        }

        //public override  Create()
        //{
        //    return Activator.CreateInstance<T>();
        //}

        //public override TDerivedEntity Create<TDerivedEntity>()
        //{
        //    return Activator.CreateInstance<TDerivedEntity>();
        //}

        //public override ObservableCollection<T> Local
        //{
        //    get { return new ObservableCollection<T>(_data); }
        //}

        Type IQueryable.ElementType
        {
            get { return _query.ElementType; }
        }

        System.Linq.Expressions.Expression IQueryable.Expression
        {
            get { return _query.Expression; }
        }

        IQueryProvider IQueryable.Provider
        {
            get { return _query.Provider; }
        }

        public DbSet<User> User { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DbSet<Vehicle> Vehicle { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        public DbSet<T1> Set<T1>() where T1 : class
        {
            throw new NotImplementedException();
        }

        public EntityEntry<T1> Entry<T1>(T1 entity) where T1 : class
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
