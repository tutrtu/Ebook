using EbookAPI.BusinessLogic.Interfaces;

using EbookAPI.DataAccess.Interfaces;
using EbookAPI.DataAccess.Repositories;
using EbookWEB.Service;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession(opt => opt.IdleTimeout = TimeSpan.FromMinutes(15));

// Register your UserService implementation
builder.Services.AddHttpClient<AccountService>();

builder.Services.AddHttpClient<AuthorService>();
builder.Services.AddHttpClient<PublisherService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
