using EStore.Business.Repositories;
using EStore.Business.Security;
using EStore.Business.Service;
using EStore.Business.Service.IService;
using EStore.Data.Repositories;

namespace EStore.Application.Config;

public static class ServiceConfiguration
{
    
    public static void AddServiceConfiguration(IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();

        services.AddScoped<ITokenProvider, TokenProvider>();
        services.AddHttpContextAccessor();
    }

    public static void AddRepositoryConfiguration(IServiceCollection services)
    {
        services.AddScoped<IMemberRepository, MemberRepository>();
    }
}