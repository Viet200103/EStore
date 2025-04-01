using EStore.Business.Repositories;
using EStore.Business.Security;
using EStore.Business.Service;
using EStore.Business.Service.IService;
using EStore.Business.Services;
using EStore.Business.Services.IServices;
using EStore.Data.Repositories;

namespace EStore.Application.Config
{
    public static class DependencyConfiguration
    {
        public static void ConfigForServices(IServiceCollection services)
        {
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IMemberService, MemberService>();

            services.AddScoped<IAuthService, AuthService>();

            services.AddScoped<ITokenProvider, TokenProvider>();
            services.AddHttpContextAccessor();
        }

        public static void ConfigForRepositories(IServiceCollection services)
        {
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
