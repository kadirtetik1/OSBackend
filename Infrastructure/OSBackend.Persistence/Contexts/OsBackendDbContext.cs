using Microsoft.EntityFrameworkCore;
using OSBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSBackend.Persistence.Contexts
{
    public class OsBackendDbContext : DbContext
    {
        public OsBackendDbContext(DbContextOptions options) : base(options)
        {}


        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }


    }
}
