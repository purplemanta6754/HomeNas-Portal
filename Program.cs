using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;


string buildVersion = "Beta v.1.0.0";
var builder = WebApplication.CreateBuilder(args);

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




app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

Console.WriteLine("You are using" + buildVersion + "Build");
Console.WriteLine("Enjoy! :)");
