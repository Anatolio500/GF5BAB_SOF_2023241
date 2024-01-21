using GF5BAB_SOF_2023241_Webapp.Controllers;
using GF5BAB_SOF_2023241_Webapp.Data;
using GF5BAB_SOF_2023241_Webapp.Logic;
using GF5BAB_SOF_2023241_Webapp.Models;
using GF5BAB_SOF_2023241_Webapp.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options
    .UseSqlServer(connectionString)
    .UseLazyLoadingProxies()
    );
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<SiteUser>(options => {

    options.SignIn.RequireConfirmedAccount = false; // Ezt kell true-ra állítani ha akarsz email megerõsítést (direkt false egyenlõre)
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 3;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    }
)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddAuthentication()
    .AddFacebook(opt =>
    {
        opt.AppId = "1021949482474546";
        opt.AppSecret = "ab9c8840dd297d0af2183a8c3c508734";
    })
    .AddMicrosoftAccount(opt =>
    {
        opt.ClientId = "26596dcd-3671-41e7-a08f-5059c5c27b2a";
        opt.ClientSecret = "iR18Q~E_ugIoFyQTUa-PRYwM6xosQjIeeI1BjcXk";
        opt.SaveTokens = true;
    }
    );


builder.Services.AddTransient<IEmailSender, EmailSender>();

builder.Services.AddScoped<HomeController>();
builder.Services.AddScoped<HomeLogic>();
builder.Services.AddScoped<MeetingController>();
builder.Services.AddScoped<MeetingLogic>();
builder.Services.AddScoped<PartController>();
builder.Services.AddScoped<PartLogic>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
