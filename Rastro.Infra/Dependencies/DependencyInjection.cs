using Microsoft.Extensions.DependencyInjection;
using Rastro.Domain.Interfaces.Repository;
using Rastro.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rastro.Infra.Dependencies
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfra(this IServiceCollection services)
        {
            // Registro de das dependencias da camada de infraestrutura
            services.AddScoped<IContasAPagarRepository, ContasAPagarRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            return services;
        }
    }
}
