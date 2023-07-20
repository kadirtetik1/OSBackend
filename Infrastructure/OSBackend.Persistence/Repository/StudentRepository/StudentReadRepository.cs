using OSBackend.Application.Repository.StudentRepository;
using OSBackend.Domain.Entities;
using OSBackend.Persistence.Contexts;

namespace OSBackend.Persistence.Repository.StudentRepository
{
    public class StudentReadRepository : ReadRepository<Student>, IStudentReadRepository
    {
        public StudentReadRepository(OsBackendDbContext context) : base(context)
        {

        }
    }
}
