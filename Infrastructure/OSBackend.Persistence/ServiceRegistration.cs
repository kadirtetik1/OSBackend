using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using OSBackend.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSBackend.Application.Repository.StudentRepository;
using OSBackend.Persistence.Repository.StudentRepository;
using OSBackend.Application.Repository.TeacherRepository;
using OSBackend.Persistence.Repository.TeacherRepository;
using OSBackend.Persistence.Repository.CourseRepository;
using OSBackend.Application.Repository.CourseRepository;
using OSBackend.Persistence.Repository;
using System.Configuration;

namespace OSBackend.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {

            services.AddDbContext<OsBackendDbContext>(options => options.UseNpgsql(Configurations.ConnectionString), ServiceLifetime.Singleton);


            services.AddSingleton<IStudentReadRepository, StudentReadRepository>();
            services.AddSingleton<IStudentWriteRepository, StudentWriteRepository>();

            services.AddSingleton<ITeacherReadRepository, TeacherReadRepository>();
            services.AddSingleton<ITeacherWriteRepository, TeacherWriteRepository>();

            services.AddSingleton<ICourseReadRepository, CourseReadRepository>();
            services.AddSingleton<ICourseWriteRepository, CourseWriteRepository>();



        }
    }
}
