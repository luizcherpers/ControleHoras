using Application.Appliaction.Domain.Interfaces;
using Application.Application.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Application.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IPerfilRepository, PerfilRepository>();
            services.AddScoped<IEquipeRepository, EquipeRepository>();
            services.AddScoped<IColaboradorRepository, ColaboradorRepository>();
        }
    }
}
