using Microsoft.EntityFrameworkCore;
using SportsStore.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

/*
 * builder.Configuration provides access to the configuration data, thus allowing the database connection
 * string to be retrieved. 
 * AddDbContext configures Entity Framework Core, registers the database context class and configures the 
 * relationship with the database.
 * 
*/
builder.Services.AddDbContext<StoreDbContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration["ConnectionStrings:SportsStoreConnection"]);
});

// Create a service for the IStoreRepository interface that uses EFStoreRepository as the implementation class
builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();

var app = builder.Build();

app.UseStaticFiles();
app.MapDefaultControllerRoute();

app.Run();
