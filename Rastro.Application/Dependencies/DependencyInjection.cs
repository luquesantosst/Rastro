using Microsoft.Extensions.DependencyInjection;
using Rastro.Application.Services;
using Rastro.Domain.Interfaces.Account;
using Rastro.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Rastro.Application.Dependencies
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Registro de das dependencias da camada de aplicação
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IContasAPagarService, ContasAPagarService>();
            
            return services;
        }
    }
}
