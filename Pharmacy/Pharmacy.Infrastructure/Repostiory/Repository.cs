﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ZPharmacy.Domain.IRepository;
using ZPharmacy.Infrastructure.Data;

namespace ZPharmacy.Infrastructure.Repostiory
{
    public class Repository<T> : IRepository<T> where T : class
    {
        readonly DbSet<T> entity;
        public PharmacyDbContext _context { get; }
        public Repository(PharmacyDbContext context)
        {
            _context = context;
            entity = context.Set<T>();
        }
        public ValueTask<EntityEntry<T>> AddAsync(T t)
        {
            return _context.Set<T>().AddAsync(t);
        }

        public ValueTask<T> GetByIdAsync(int id)
        {
            return _context.Set<T>().FindAsync(id);
        }
        public void AddRangeAsync(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRangeAsync(entities);
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return entity.Where(expression);
        }
        public Task<List<T>> GetAllAsync()
        {
            return _context.Set<T>().AsNoTracking().ToListAsync();
        }
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    }
}
