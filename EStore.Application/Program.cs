using EStore.Application.Components;
using EStore.Application.Config;
using EStore.Business.Security;
using EStore.Business.Mapper;

var builder = WebApplication.CreateBuilder(args);

DatabaseConfiguration.Configure(builder.Configuration, builder);
SecurityConfiguration.ConfigureAuthJwt(builder.Configuration, builder.Services);
ServiceConfiguration.AddRepositoryConfiguration(builder.Services);
ServiceConfiguration.AddServiceConfiguration(builder.Services);

var jwtSection = builder.Configuration.GetSection("JwtOptions");
builder.Services.Configure<JwtOptions>(jwtSection);

builder.Services
    .AddRazorComponents()
    .AddInteractiveServerComponents();

DatabaseConfigure.Configure(builder.Configuration, builder);
DependencyConfigure.ConfigForServices(builder.Services);
DependencyConfigure.ConfigForRepositories(builder.Services);

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

app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();