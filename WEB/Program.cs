using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System;
using AppTest.Models;
using AppTest.Models.Entities;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthorization();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.LoginPath = "/Home/LoginPage";
            options.AccessDeniedPath = "/Home/Index";
        });


builder.Services.AddAuthorization();
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
app.UseAuthentication();
app.UseAuthorization();

app.MapPost("/login", async (HttpContext context) =>
{
    AppDbContext db = new AppDbContext();
    // �������� �� ����� email � ������
    var form = context.Request.Form;
    // ���� email �/��� ������ �� �����������, �������� ��������� ��� ������ 400
    if (!form.ContainsKey("Login") || !form.ContainsKey("Password"))
        return Results.BadRequest("Email �/��� ������ �� �����������");

    string login = form["Login"];
    string password = form["Password"];

    UserEntity? user = db.Users.Where(p => p.Login == login || p.Email == login).Include(c=>c.Roles).AsNoTracking().FirstAsync().Result;
    // ���� ������������ �� ������, ���������� ��������� ��� 401
    if (user is null) return Results.Unauthorized();
    if (user.Password != password) return Results.Unauthorized();

    var claims = new List<Claim> { 
        new Claim(ClaimTypes.Name, user.Login)
    };
    foreach(var c in user.Roles)
    {
        claims.Add(new Claim(ClaimTypes.Role,c.Name));
    }
    // ������� ������ ClaimsIdentity
    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
    // ��������� ������������������ ����
    await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
    return Results.Redirect("/Home/Index");
});

app.MapGet("/logout", async (HttpContext context) =>
{
    await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    return Results.Redirect("/Home/LoginPage");
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
