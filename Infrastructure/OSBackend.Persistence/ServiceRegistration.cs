using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using OSBackend.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSBackend.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {

            services.AddDbContext<OsBackendDbContext>(options => options.UseNpgsql(Configurations.ConnectionString));

        }
    }
}
