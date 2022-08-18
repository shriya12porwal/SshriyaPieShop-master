using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SshriyaPieShop.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

string connString = builder.Configuration.GetConnectionString("AppDbContextConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connString);

});


builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<AppDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddScoped<IPieRepository, PieRepository>();
//builder.Services.AddSingleton<IPieRepository, PieRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<ShoppingCart>(sp => ShoppingCart.GetCart(sp));

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddHttpContextAccessor();//middlewarecomponents,request,response,session,user,caching,service

builder.Services.AddSession();
builder.Services.AddScoped<ShoppingCart>(sp => ShoppingCart.GetCart(sp));
var app = builder.Build();








//$$$$$$$$$$$$$$$$$MiddleWare Components

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=pie}/{action=PiesOfTheWeek}/{id?}");
app.MapRazorPages();
app.Run();
