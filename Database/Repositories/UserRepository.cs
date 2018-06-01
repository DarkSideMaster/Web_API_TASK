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

        public User Create(User item)
        {
            var entity = _context.Users.Add(item).Entity;
            _context.SaveChanges();
            return entity;
        }

        public User Update(User item)
        {
            var entity = _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }

        public User Delete(int id)
        {
            User user = _context.Users.Find(id);

            var entity = _context.Users.Remove(user).Entity;
            _context.SaveChanges();
            return entity;
        }
    }
}
