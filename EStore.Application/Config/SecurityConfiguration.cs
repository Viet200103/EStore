using System.Security;
using System.Text;
using EStore.Business.Contants;
using EStore.Business.Security;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace EStore.Application.Config;

public static class SecurityConfiguration
{
    public static void ConfigureAuthJwt(IConfiguration configuration, IServiceCollection services)
    {
        var jwtOptions = configuration.GetSection("JwtOptions").Get<JwtOptions>();

        if (jwtOptions == null)
        {
            throw new SecurityException("Jwt Configuration is missing");
        }
        
        AuthenticationBuilder authenticationBuilder = services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        });

        authenticationBuilder.AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey)),
                ValidAudience = jwtOptions.ValidAudience,
                ValidIssuer = jwtOptions.ValidIssuer,
            };

            options.Events = new JwtBearerEvents
            {
                OnMessageReceived = context =>
                {
                    string? authToken = context.Request.Query[Utils.AccessToken];
                    if (!authToken.IsNullOrEmpty())
                    {
                        context.Token = authToken;
                    }
                    return Task.CompletedTask;
                },
                OnChallenge = context =>
                {
                    context.HandleResponse();
                    context.Response.Redirect("/login");
                    return Task.CompletedTask;
                },
                OnForbidden = context =>
                {
                    context.Response.Redirect("/not-found");
                    return Task.CompletedTask;
                }
            };
        });
    }
}