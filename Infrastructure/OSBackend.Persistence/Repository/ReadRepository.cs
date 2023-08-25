﻿using OSBackend.Application.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using OSBackend.Domain.Entities.Common;
using OSBackend.Persistence.Contexts;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OSBackend.Domain.Entities;

namespace OSBackend.Persistence.Repository
{

    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        readonly private OsBackendDbContext _context;

        public ReadRepository(OsBackendDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return query;
        }
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.Where(method);
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return query;
        }
        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = Table.AsNoTracking();
            }
            return await query.FirstOrDefaultAsync(method);
        }
        public async Task<T> GetByIdAsync(string id , bool tracking = true)
        //=> await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        //=> await Table.FindAsync(Guid.Parse(id));

        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = Table.AsNoTracking();
            }

            return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));


        }

    }
}
