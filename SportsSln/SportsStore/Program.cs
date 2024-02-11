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

builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

// Receives the collection of services that have been registered and passes the collection to the GetCart method
// of the SessionCart class. Cart service will be handled by creating SessionCart objects, which will serialize
// themselves as session data when they are modified.
builder.Services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
// Specifies that the same object should always be used. Use the HttpContextAccessor class when implementations of
// the IHttpContextAccessor interface are required.
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();

app.UseStaticFiles();
app.UseSession();

app.MapControllerRoute("catPage", "{category}/Page{productPage:int}", new { Controller = "Home", action = "Index" });
app.MapControllerRoute("page", "Page/{productPage:int}", new { Controller = "Home", action = "Index", productPage = 1 });
app.MapControllerRoute("category", "{category}", new { Controller = "Home", action = "Index", productPage = 1 });
app.MapControllerRoute("pagination", "Products/Page{ProductPage}", new { Controller = "Home", action = "Index", 
    productPage = 1 });

app.MapDefaultControllerRoute();
app.MapRazorPages();

SeedData.EnsurePopulated(app);

app.Run();
