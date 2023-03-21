using HomeNasPortal.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Services;

// Obtener detalles del cliente
var browserService = serviceProvider.GetService<IWebAssemblyHostEnvironment>();
var browserName = browserService.Browser;
var os = browserService.Runtime.OperatingSystem;

// Obtener detalles del servidor
var navigationManager = serviceProvider.GetService<NavigationManager>();
var baseUri = navigationManager.BaseUri;
var serverUri = navigationManager.ToAbsoluteUri(baseUri).Host;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();

// Configure el canal de peticiones HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // El valor HSTS por defecto es de 30 días. Es posible que desee cambiarlo para escenarios de producción, consulte https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
