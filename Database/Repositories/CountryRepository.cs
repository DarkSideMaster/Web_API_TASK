﻿using System;
using System.Collections.Generic;
using System.Linq;
using Database.Interfaces;
using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public class CountryRepository : IRepository<Country>
    {
        private EnterpriseContext _context;

        public CountryRepository(EnterpriseContext context)
        {
            _context = context;
        }

        public List<Country> Entities => _context.Сountries.ToList();

        public Country GetEntity(int id)
        {
            return _context.Сountries
                .AsQueryable()
                .FirstOrDefault(country => country.Id == id);
        }

        public Country Create(Country item)
        {
            var createCountryentity = _context.Сountries.Add(item).Entity;
            _context.SaveChanges();
            return createCountryentity;
        }

        public Country Update(Country item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
            return _context.Entry(item).Entity;
        }

        public Country Delete(int id)
        {
            Country country = _context.Сountries.Find(id);

            _context.SaveChanges();
            return _context.Сountries.Remove(country).Entity; 
        }
    }
}
