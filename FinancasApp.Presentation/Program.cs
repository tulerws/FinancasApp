using FinancasApp.Domain.Interfaces.Repositories;
using FinancasApp.Domain.Interfaces.Services;
using FinancasApp.Domain.Services;
using FinancasApp.Infra.Data.Repositories;
using FinancasApp.Presentation;
using FinancasApp.Presentation.Middlewares;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Habilitando o uso de sess�es no projeto
builder.Services.AddSession();

//configurar as inje��es de depend�ncia do projeto
DependencyInjection.Register(builder.Services);

//habilitando o uso de cookies no projeto
builder.Services.Configure<CookiePolicyOptions>(options => {
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

//habilitando a pol�tica de autentica��o por Cookies no projeto
builder.Services.AddAuthentication
    (CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseMiddleware<CacheControl>();

app.UseRouting();

app.UseSession();

app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default", //configura��o da p�gina inicial
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
