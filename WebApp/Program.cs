using CoreLogic.Data;
using CoreLogic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();

        builder.Services.AddDbContext<MyContextDB>();

        builder.Services.AddAuthentication("CookieAuth")
            .AddCookie("CookieAuth", config =>
            {
                //config.Cookie.Name = "User.Cookie";
                config.Cookie.Name = "User";
                config.LoginPath = "/Login";
                config.LogoutPath = "/Logout";
            });


        /*builder.Services.AddAuthentication("CookieAuth")
            .AddCookie("CookieAuth", config =>
            {
                config.Cookie.Name = "Seller.Cookie";
                config.LoginPath = "/SellerLogin";
                config.LogoutPath = "/Logout";
            });
        */

        var app = builder.Build();



        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }



        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();
    }
}