using eTickets.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ErikNoren.Extensions.Configuration;
using ErikNoren.Extensions.Configuration.SqlServer;

var builder = WebApplication.CreateBuilder(args);

// I tried this to add the database
builder.Configuration.AddSqlServer(config =>
{
    config.ConnectionString = builder.Configuration.GetConnectionString("identifier.sqlite");
    config.RefreshInterval = TimeSpan.FromMinutes(1);
});

// Db Configuration

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();