using AppSale.Application.Services;
using AppSale.Domain.Entities.Security;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AppSale.Application
{
    public static class ApplicationModuleDependency
    {
        public static void AddApplicationModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            #region Autentication
            // Configurando a dependência para a classe de validação
            // de credenciais e geração de tokens
            services.AddScoped<AuthenticationServiceManager>();

            var tokenConfigurations = new TokenConfiguration();
            new ConfigureFromConfigurationOptions<TokenConfiguration>(
                configuration.GetSection("TokenConfigurations"))
                    .Configure(tokenConfigurations);
            services.AddSingleton(tokenConfigurations);

            // Aciona a extensão que irá configurar o uso de
            // autenticação e autorização via tokens
            services.AddJwtSecurity(tokenConfigurations);

            // Configura a dependência da classe que cria usuários
            // para testes da API
            services.AddTransient<IdentityInitializer>();
            #endregion
        }
    }
}
