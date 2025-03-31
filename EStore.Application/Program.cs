using EStore.Application.Components;
using EStore.Application.Config;
using EStore.Business.Mapper;
using EStore.Business.Repositories;
using EStore.Business.Service;
using EStore.Business.Service.IService;
using EStore.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

DatabaseConfigure.Configure(builder.Configuration, builder);

builder.Services
    .AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddQuickGridEntityFrameworkAdapter();

builder.Services.AddScoped<IMemberRepository, MemberRepository>();

builder.Services.AddScoped<IMemberService, MemberService>();

builder.Services.AddAutoMapper(typeof(CommonMapperProfile));
builder.Services.AddAutoMapper(typeof(MappingProfile));

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