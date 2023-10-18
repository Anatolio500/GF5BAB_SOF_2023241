using GF5BAB_SOF_2023241_Webapp.Data;
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
        opt.AppId = "201877619599899";
        opt.AppSecret = "61252d640f38fc0df806d8b5c7df182f";
    });


builder.Services.AddTransient<IEmailSender, EmailSender>();

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
