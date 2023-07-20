using OSBackend.Application.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using OSBackend.Domain.Entities.Common;
using OSBackend.Persistence.Contexts;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

        public IQueryable<T> GetAll()
            => Table;
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
            => Table.Where(method);
        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)

            => await Table.FirstOrDefaultAsync(method);
        public async Task<T> GetByIdAsync(string id)
        => await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        
        
    }
}
