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
    }
}
