using Microsoft.EntityFrameworkCore;
using OSBackend.Application.Repository.CourseRepository;
using OSBackend.Domain.Entities;
using OSBackend.Persistence.Contexts;


namespace OSBackend.Persistence.Repository.CourseRepository
{
    public class CourseReadRepository : ReadRepository<Course>, ICourseReadRepository
    {
        public CourseReadRepository(OsBackendDbContext context) : base(context)
        {

        }

        public async Task<List<Course>> GetByIdAsyncTeacher(string TeacherId, bool tracking = true)

        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = Table.AsNoTracking();
            }

            //return await query.FirstOrDefaultAsync(data => data.TeacherId == Guid.Parse(TeacherId));
            
            return await query.Where(data => data.TeacherId == Guid.Parse(TeacherId)).ToListAsync();

        }
    }
}
