using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DistanciaAmigos.Data;
using DistanciaAmigos.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using WebApi_JWT.ProviderJWT;

namespace DistanciaAmigos
{
    public class Startup
    {

        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
          
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(option =>
                {
                    option.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = false,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = "Teste.Securiry.Bearer",
                        ValidAudience = "Teste.Securiry.Bearer",
                        IssuerSigningKey = WebApi_JWT.ProviderJWT.JWTSecurityKey.Create("Secret_Key-12345678")
                    };

                    option.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                            return Task.CompletedTask;
                        },
                        OnTokenValidated = context =>
                        {
                            Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                            return Task.CompletedTask;
                        }
                    };
                });
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("http://localhost:3000",
                                        "http://www.contoso.com").AllowAnyHeader()
                                                                  .AllowAnyMethod();
                });
                         options.AddPolicy("AnotherPolicy",
                builder =>
                {
                    builder.WithOrigins("http://localhost:3000")
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                });
            });
   

            services.AddAuthorization(options =>
            {
                options.AddPolicy("UsuarioAPI",
                    policy => policy.RequireClaim("UsuarioAPINumero"));
            });
            
            services.AddMvc();
           

            services.AddScoped<MyContext, MyContext>();
            
            services.AddTransient<LocalizacaoRepository, LocalizacaoRepository>();

        }

                // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var contexts = serviceScope.ServiceProvider.GetRequiredService<MyContext>();
                contexts.Database.EnsureCreated();
            }
            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthentication();
            app.UseStaticFiles();         
            app.UseMvcWithDefaultRoute();
        }
    }
}
