using System;
using System.Collections.Generic;
using System.Linq;
using Database.Interfaces;
using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private EnterpriseContext _context;

        public UserRepository(EnterpriseContext context)
        {
            _context = context;
        }

        public List<User> Entities => _context.Users.ToList();

        public User GetEntity(int id)
        {
            return _context.Users
                .AsQueryable()
                .FirstOrDefault(user => user.Id == id);
        }

        public void Create(User item)
        {
            _context.Users.Add(item);
            _context.SaveChanges();
        }

        public void Update(User item)
        {
            if (item != null)
            {
                _context.Entry(item).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            User user = _context.Users.Find(id);

            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

    }
}
