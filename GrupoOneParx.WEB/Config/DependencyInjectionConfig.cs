using GrupoOneParx.Business.Interfaces;
using GrupoOneParx.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace GrupoOneParx.WEB.Config
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();

            return services;
        }
    }
}
