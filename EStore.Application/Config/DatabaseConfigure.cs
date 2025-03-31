using EStore.Data.Database;
using Microsoft.EntityFrameworkCore;

namespace EStore.Application.Config
{
    public static class DatabaseConfigure
    {
        public static void Configure(IConfiguration configuration, WebApplicationBuilder builder)
        {
            string? connectionString = configuration.GetConnectionString("DefaultConnection");

            if (connectionString == null)
            {
                throw new InvalidOperationException("MentorLinkDb connection string not found");
            }

            builder.Services.AddDbContext<EStoreContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }
    }
}
