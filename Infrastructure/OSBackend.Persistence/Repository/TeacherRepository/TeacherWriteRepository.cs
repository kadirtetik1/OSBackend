using OSBackend.Application.Repository.TeacherRepository;
using OSBackend.Domain.Entities;
using OSBackend.Persistence.Contexts;


namespace OSBackend.Persistence.Repository.TeacherRepository
{
    public class TeacherWriteRepository : WriteRepository<Teacher>, ITeacherWriteRepository
    {
        public TeacherWriteRepository(OsBackendDbContext context) : base(context)
        {
        }
    }
}
