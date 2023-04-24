using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DivergentWarehouseTest.Data;
using DivergentWarehouseTest.Models;
using DivergentWarehouseTest.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DivergentWarehouseTestContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DivergentWarehouseTestContext") ?? throw new InvalidOperationException("Connection string 'DivergentWarehouseTestContext' not found.")));
builder.Services.AddScoped<IWarehouseService, WarehouseService>();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//app.UseAuthorization();

app.Run();
