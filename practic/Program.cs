using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using practic.DAL;
using practic.Models;

var builder = WebApplication.CreateBuilder(args);

/*builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));*/
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton(typeof(ISQL_Connection), new SQL_Connection());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index1}/{id?}");

app.Run();
