using Microsoft.EntityFrameworkCore;
using StreamPet.Models;
using Pomelo.EntityFrameworkCore.MySql;
using StreamPet.Helper;

var builder = WebApplication.CreateBuilder(args);
/*builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStrings"));
});*/



// Add services to the container.
builder.Services.AddControllersWithViews(); 
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<StreamPet.Helper.ISession, Session>();

builder.Services.AddSession(o =>
{
    o.IOTimeout = TimeSpan.FromHours(1);
    o.Cookie.HttpOnly = true;
    o.Cookie.IsEssential = true;
}
    
    ) ;


builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.29-MySql")
        );
});

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
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
