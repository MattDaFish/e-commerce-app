using JustSports.Core.Interfaces;
using Infrastructure.Data;
using JustSports.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace JustSports.WebApi.Extensions
{
    internal static class ServiceExtensions
    {
        internal static IServiceCollection AddCustomAppServices(this IServiceCollection services, WebApplicationBuilder builder)
        {
            if (services == null)
                return null;

            if (builder == null)
                return null;

            services.AddCustomCors();
            services.AddCustomSwagger();
            services.AddDomainServices();
            services.AddDataServices(builder);

            return services;
        }

        public static void AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();

        }

        public static void AddDataServices(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddDbContext<JustSportsDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("JustSports")));
        }

        private const string customAllowedSpecificOrigins = "_customAllowedSpecificOrigins";

        public static void AddCustomCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: customAllowedSpecificOrigins,
                    builder =>
                    {
                        //builder.AllowAnyOrigin()
                        //### Angular opens on port 4200
                        builder.WithOrigins("http://localhost:4200")
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
            });
        }

        public static void UseCustomCors(this IApplicationBuilder app)
        {
            app.UseCors(customAllowedSpecificOrigins);
        }

        private const string swaggerTitle = "JustSports API";
        
        public static void AddCustomSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = swaggerTitle,
                    Description = "Provides access to JustSports Api engine",
                    Contact = new OpenApiContact
                    {
                        Name = "JustSports",
                        Email = "hello@justsports.co.za"
                    }
                });

                s.OrderActionsBy(apiDesc =>
                {
                    return apiDesc.GroupName;
                    //return apiDesc.HttpMethod;
                });

                //var apiSecurityScheme = new OpenApiSecurityScheme()
                //{
                //    Reference = new OpenApiReference
                //    {
                //        Type = ReferenceType.SecurityScheme,
                //        Id = "Bearer"
                //    },
                //    Description = "API Key header. Example: \"X-API-KEY: {key}\"",
                //    Name = "X-API-KEY",
                //    In = ParameterLocation.Header,
                //    Type = SecuritySchemeType.ApiKey,
                //    Scheme = "Bearer"
                //};

                //s.AddSecurityDefinition("Bearer", apiSecurityScheme);

                //var securityRequirement = new OpenApiSecurityRequirement {
                //    {apiSecurityScheme, new[] { "Bearer"}}};

                //s.AddSecurityRequirement(securityRequirement);

                //### Set the comments path for the swagger json and ui.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                s.IncludeXmlComments(xmlPath);

            });

        }

        public static void UseCustomSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", swaggerTitle);
            });

        }

    }
}
