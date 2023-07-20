using OSBackend.Application.Repository.TeacherRepository;
using OSBackend.Domain.Entities;
using OSBackend.Persistence.Contexts;


namespace OSBackend.Persistence.Repository.TeacherRepository
{
    public class TeacherReadRepository : ReadRepository<Teacher>, ITeacherReadRepository
    {
        public TeacherReadRepository(OsBackendDbContext context) : base(context)
        {
        }
    }
}
