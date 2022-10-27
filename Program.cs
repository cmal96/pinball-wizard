using Darnton.Blazor.DeviceInterop.Geolocation;
using MatBlazor;
using PinballWizard.Interfaces;
using PinballWizard.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMatBlazor();
builder.Services.AddSingleton<IRegionService, RegionService>();
builder.Services.AddSingleton<ILocationService, LocationService>();
builder.Services.AddTransient<ICoordinatesService, CoordinatesService>();
builder.Services.AddScoped<IGeolocationService, GeolocationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
