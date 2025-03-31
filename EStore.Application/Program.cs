using EStore.Application.Components;
using EStore.Business.Repository;
using EStore.Business.Services;
using EStore.Business.Services.IServices;
using EStore.Data.Database;
using EStore.Data.Repositories;
using MentorLink.Business.Mapper;
using Microsoft.EntityFrameworkCore;

using EStore.Application.Config;


var builder = WebApplication.CreateBuilder(args);
DatabaseConfigure.Configure(builder.Configuration, builder);

builder.Services.AddDbContext<EStoreDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddQuickGridEntityFrameworkAdapter();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();




builder.Services
    .AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddQuickGridEntityFrameworkAdapter();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
    app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();