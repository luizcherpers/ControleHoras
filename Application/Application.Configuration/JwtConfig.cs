using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Application.Application.Configuration
{
    public static class JwtConfig
    {
        public static void AddJwtConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var secretKey = configuration.GetValue<string>("SecretKey");
            var key = Encoding.ASCII.GetBytes(secretKey);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "Controle de horas",
                        ValidAudience = "Controle de horas",
                        IssuerSigningKey = new SymmetricSecurityKey(key)

                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            Console.WriteLine($"Token inválido...: {context.Exception.Message} ");
                            return Task.CompletedTask;
                        },
                        OnTokenValidated = context =>
                        {
                            Console.WriteLine($"Token válido...: {context.SecurityToken} ");
                            return Task.CompletedTask;
                        }
                    };
                });
        }
    }
}
