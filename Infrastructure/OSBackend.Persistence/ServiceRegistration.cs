
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
using Microsoft.Extensions.DependencyInjection;

namespace OSBackend.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {

            services.AddDbContext<OsBackendDbContext>(options => options.UseNpgsql(Configurations.ConnectionString));


            services.AddScoped<IStudentReadRepository, StudentReadRepository>();
            services.AddScoped<IStudentWriteRepository, StudentWriteRepository>();
                     
            services.AddScoped<ITeacherReadRepository, TeacherReadRepository>();
            services.AddScoped<ITeacherWriteRepository, TeacherWriteRepository>();
                     
            services.AddScoped<ICourseReadRepository, CourseReadRepository>();
            services.AddScoped<ICourseWriteRepository, CourseWriteRepository>();



        }
    }
}
