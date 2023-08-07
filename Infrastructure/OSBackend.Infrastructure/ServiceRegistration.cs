using Microsoft.Extensions.DependencyInjection;
using OSBackend.Application.Abstractions.Token;
using OSBackend.Infrastructure.Services.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSBackend.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ITokenHandler, TokenHandler>();
        }
    }
}
