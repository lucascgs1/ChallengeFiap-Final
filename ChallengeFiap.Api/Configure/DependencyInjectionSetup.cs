using ChallengeFiap.Data;
using ChallengeFiap.Data.Interfaces;
using ChallengeFiap.Services;
using ChallengeFiap.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ChallengeFiap.Api.Configure
{
    public static class DependencyInjectionSetup
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            #region repositorios

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IEventoRepository, EventoRepository>();

            #endregion repositorios

            #region servicos

            services.AddTransient<IUsuarioServices, UsuarioServices>();
            services.AddTransient<IUsuarioServices, UsuarioServices>();
            services.AddTransient<IEventoService, EventoService>();

            #endregion servicos
        }
    }
}
