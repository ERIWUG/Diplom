using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using AppTest.Models;
using AppTest.Models.Entities;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>{
            options.LoginPath = "/Home/LoginPage";
            options.AccessDeniedPath = "/Home/Index";
        });
builder.Services.AddAuthorization();
var app = builder.Build();
if (!app.Environment.IsDevelopment()){
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapPost("/login", async (HttpContext context) =>{
    AppDbContext db = new AppDbContext();
    var form = context.Request.Form;
    if (!form.ContainsKey("Login") || !form.ContainsKey("Password"))
        return Results.Redirect("/Home/LoginPage");
    string login = form["Login"];string password = form["Password"];
    UserEntity? user = db.Users.Where(p => p.Login == login || p.Email == login).Include(c=>c.Roles).AsNoTracking().FirstAsync().Result;
    if (user is null) return Results.Unauthorized();
    if (user.Password != password) return Results.Unauthorized();
    var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.Login)};
    foreach(var c in user.Roles){claims.Add(new Claim(ClaimTypes.Role,c.Name));}
    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
    await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
    return Results.Redirect("/Home/Index");
});
app.MapGet("/logout", async (HttpContext context) =>{
    await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    return Results.Redirect("/Home/LoginPage");
});
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();





