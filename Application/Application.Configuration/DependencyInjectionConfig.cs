using Application.Appliaction.Domain.Interfaces;
using Application.Application.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Application.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IPerfilRepository, PerfilRepository>();
            services.AddScoped<IEquipeRepository, EquipeRepository>();
            services.AddScoped<IColaboradorRepository, ColaboradorRepository>();
            services.AddScoped<IColaboradorEquipeRepository, ColaboradorEquipeRepository>();
            services.AddScoped<IProjetoRepository, ProjetoRepository>();
        }
    }
}
