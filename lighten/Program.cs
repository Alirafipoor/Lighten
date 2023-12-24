using Amazon.OpsWorks.Model;
using DAL.Db.FacadPattern;
using DAL.Db.IdnetityEntity;
using DAL.Services.Email;
using DAL.Services.Identity;
using DAL.Services.Product.FacadPattern;
using Domain.Db;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DataBaseContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString(""));
});

builder.Services.AddDbContext<DataBaseContextIdentity>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString(""));
});
//
builder.Services.AddScoped<IEmailService, EmailService>(); //Add Email Service

builder.Services.AddScoped<IProductFacad, ProductFacad>();//Add product Facad

builder.Services.AddIdentity<user, IdentityRole>()
    .AddEntityFrameworkStores<DataBaseContextIdentity>()
    .AddDefaultTokenProviders()
    .AddErrorDescriber<CustomIdentityErorr>();

builder.Services.Configure<IdentityOptions>(option => //Identity Options
{
    option.User.AllowedUserNameCharacters = "qwertyuioplkjhgfdsazxcvbnm1234567890";
    option.User.RequireUniqueEmail = true;

    option.Password.RequireDigit = true;
    option.Password.RequireLowercase = false;
    option.Password.RequireUppercase = true;
    option.Password.RequireNonAlphanumeric = true;
    option.Password.RequiredUniqueChars = 1;

    option.Lockout.MaxFailedAccessAttempts = 5;
    option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);

    option.SignIn.RequireConfirmedAccount = false;
    option.SignIn.RequireConfirmedEmail = false;
    option.SignIn.RequireConfirmedPhoneNumber = false;

});



builder.Services.ConfigureApplicationCookie(option =>
{
    option.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    option.LoginPath = "/UserController1/Login";
    option.SlidingExpiration = true;
});

builder.Services.AddAuthorization(option =>
{
    option.AddPolicy("admin", policy =>
    {
        policy.RequireRole("member");
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
