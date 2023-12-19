using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyDataBases.FundationDbContext;
using WebApp.BaseServices;

var builder = WebApplication.CreateBuilder(args);

#region  Add services to the container.
// DBContext
var connectionString = builder.Configuration.GetConnectionString("AzureDbFundation") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<FundationDbContext>(options =>
    // change the default migrations assembly
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
        
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
