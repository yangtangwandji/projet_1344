using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Projet.ExtensionMethods;
using Projet.Models;
using Projet.Services.AuthService;
using Projet.Services.JoueurService;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ContextConnection"))
);

SecurityMethods.AddJwtAuthentication(builder.Services, builder.Configuration);
builder.Services.AddCors(options =>
{
    options.AddPolicy("DEFAULT_POLICY", policy =>
    {
        policy.WithOrigins("*")
               .AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

//builder.Services.AddDefaultIdentity<User>(options =>
//{
//    options.Password.RequireLowercase = false;
//    options.Password.RequireUppercase = false;
//    options.Password.RequireNonAlphanumeric = false;
//    options.Password.RequireDigit = false;
//}).AddRoles<IdentityRole>()
//  .AddEntityFrameworkStores<ApiContext>();

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
//builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IJoueurService, JoueurService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors("DEFAULT_POLICY");
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
