using Demo.Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Infrastructure.Data
{
    public abstract class Repository<TAggregateRoot, Tkey> : IRepository<TAggregateRoot, Tkey>, IDisposable
           where TAggregateRoot : class, IAggregateRoot<Tkey>
            where Tkey : IComparable

    {
        private  DbContext _dbContext;
        private  DbSet<TAggregateRoot> _dbSet;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TAggregateRoot>();
        }

        public void add(TAggregateRoot entity)
        {
            _dbSet.Add(entity);
        }

        public async Task addAsync(TAggregateRoot entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
