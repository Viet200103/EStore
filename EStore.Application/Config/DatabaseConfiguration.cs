using EStore.Data.Database;
using Microsoft.EntityFrameworkCore;

namespace EStore.Application.Config;

public static class DatabaseConfiguration
{

    public static void Configure(IConfiguration configuration, WebApplicationBuilder builder)
    {
        string? connectionString = configuration.GetConnectionString("DefaultConnection");

        if (connectionString == null)
        {
            throw new InvalidOperationException("EStore connection string not found");
        }
        
        builder.Services.AddDbContext<EStoreDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
    }
}