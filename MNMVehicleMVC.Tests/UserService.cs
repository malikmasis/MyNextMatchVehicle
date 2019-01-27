using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MNMVehicleMVC.Data;
using MNMVehicleMVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNMVehicleMVC.Tests
{
    public class UserService
    {
        private IStoreAppContext _context;

        public UserService(IStoreAppContext context)
        {
            _context = context;
        }

        public EntityEntry<User> AddBlog(string name, string url)
        {
            var blog = _context.User.Add(new User { Name = name, SurName = url });
            _context.SaveChanges();

            return blog;
        }

        public List<User> GetAllBlogs()
        {
            var query = from b in _context.User
                        orderby b.Name
                        select b;

            return query.ToList();
        }

        public async Task<List<User>> GetAllBlogsAsync()
        {
            var query = from b in _context.User
                        orderby b.Name
                        select b;

            return await query.ToListAsync();
        }
    }
}
