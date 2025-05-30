﻿using EStore.Application.Components;
using EStore.Application.Config;
using EStore.Business.Contants;
using EStore.Business.Mappers;
using EStore.Business.Security;

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


builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddQuickGridEntityFrameworkAdapter();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

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