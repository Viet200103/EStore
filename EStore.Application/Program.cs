using EStore.Application.Components;
using EStore.Application.Config;
using EStore.Business.Security;
using EStore.Business.Mapper;

var builder = WebApplication.CreateBuilder(args);

DatabaseConfiguration.Configure(builder.Configuration, builder);
SecurityConfiguration.ConfigureAuthJwt(builder.Configuration, builder.Services);
DependencyConfiguration.ConfigForServices(builder.Services);
DependencyConfiguration.ConfigForRepositories(builder.Services);

var jwtSection = builder.Configuration.GetSection("JwtOptions");
builder.Services.Configure<JwtOptions>(jwtSection);

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

app.Map("/logout", (context) =>
{
    context.Response.Cookies.Delete(Utils.AccessToken);
    context.Response.Redirect("/login");
    return Task.CompletedTask;
});

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();