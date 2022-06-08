using Microsoft.OpenApi.Models;

namespace JustSports.WebApi.Extensions
{
    public static class SwaggerServiceExtension
    {
        private const string swaggerTitle = "JustSports API";

        public static IServiceCollection AddSwaggerDoc(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo { Title = swaggerTitle, Version = "v1" });

                var apiSecurityScheme = new OpenApiSecurityScheme()
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },
                    Description = "API Key header. Example: \"X-API-KEY: {key}\"",
                    Name = "X-API-KEY",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                };

                s.AddSecurityDefinition("Bearer", apiSecurityScheme);
                
                var securityRequirement = new OpenApiSecurityRequirement { 
                    {apiSecurityScheme, new[] { "Bearer"}}};
                
                s.AddSecurityRequirement(securityRequirement);
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerDoc(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", swaggerTitle);
            });
            return app;
        }
    }
}