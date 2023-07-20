using OSBackend.Application.Repository.StudentRepository;
using OSBackend.Domain.Entities;
using OSBackend.Persistence.Contexts;


namespace OSBackend.Persistence.Repository.StudentRepository
{
    public class StudentWriteRepository : WriteRepository<Student>, IStudentWriteRepository
    {
        public StudentWriteRepository(OsBackendDbContext context) : base(context)
        {
        }
    }
}
