using AppSale.Application;
using AppSale.Application.Services;
using AppSale.DataBase;
using AppSale.Domain.Entities.Security;
using AppSale.Filter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppSale
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            //Injection Modules
            services.AddDataBaseModule(Configuration);
            services.AddApplicationModule(Configuration);

            services.AddSwaggerGen(c =>
            {
                c.DocumentFilter<SwaggerTagFilter>();
                c.SwaggerDoc(
                    "v1"
                    , new OpenApiInfo
                    {
                        Title = "AppSale",
                        Version = "v1",
                        Contact = new OpenApiContact
                        {
                            Name = "Bruno Takemoto",
                            Email = "brunotakemoto@gmail.com",
                            Url = new Uri("https://www.linkedin.com/in/bruno-takemoto-26b71915/"),
                        }
                    }
                );
                c.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Description = "JWT Authorization header using the Bearer scheme."
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "bearerAuth" }
                        },
                        new string[] {}
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IdentityInitializer identityInitializer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AppSale v1"));
            }

            app.UseCors(builder => builder.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader());

            //app.UseHttpsRedirection();

            // Criação de estruturas, usuários e permissões
            // na base do ASP.NET Identity Core (caso ainda não
            // existam)
            identityInitializer.Initialize();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
