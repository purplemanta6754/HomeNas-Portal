using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;


var buildVersion = "Beta v.1.0.0";
var builder = WebApplication.CreateBuilder(args);

Console.WriteLine("You are using HomeNas Portal " + buildVersion + " Build");

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var app = builder.Build();

// Configure el canal de peticiones HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // El valor HSTS por defecto es de 30 días. Es posible que desee cambiarlo para escenarios de producción, consulte https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


Console.WriteLine("Enjoy! :)");



app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

Console.WriteLine("Thanks for using HomeNas Portal " + buildVersion, ". Be sure to check https://github.com/purplemant5467/HomeNas-Portal/releases/latest every month to keep the software up to date.");
