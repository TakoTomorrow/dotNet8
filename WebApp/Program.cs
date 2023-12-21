using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MyDataBases.FundationDbContext;
using MyDataBases.FundationDbContext.Models;
using WebApp.BaseServices;

var builder = WebApplication.CreateBuilder(args);

#region  Add services to the container.
// DBContext
var connectionString = builder.Configuration.GetConnectionString("AzureDbFundation") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<FundationDbContext>(options =>
    // change the default migrations assembly
    options.UseSqlServer(connectionString));

// External Auth
var googleClientId = builder.Configuration["Authentication__Google__ClientId"] ?? throw new Exception("Google OpenId : ClientId is null.");
var googleClientSecrect = builder.Configuration["Authentication__Google__ClientSecret"]?? throw new Exception("Google OpenId : ClientSecret is null.");

builder.Services.AddAuthentication().AddGoogle(googleOptions =>
{
    googleOptions.ClientId = googleClientId;
    googleOptions.ClientSecret = googleClientSecrect;
});

// Identity
IdentityService.Configuration(builder);

// Razor
builder.Services.AddRazorPages();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
