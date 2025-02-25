using Microsoft.EntityFrameworkCore;
using AspProject1.Models;  // DbContext s�n�f�n�n bulundu�u namespace

var builder = WebApplication.CreateBuilder(args);

// appsettings.json'dan ba�lant�y� al
var connectionString = builder.Configuration.GetConnectionString("AracTakipSistemiDB");

// DbContext'i DI container'a ekle
builder.Services.AddDbContext<AraclarContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Middleware yap�land�rmas�
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
