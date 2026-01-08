using Azure.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using WebApplication1.Models;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddControllersWithViews();
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("EFCoreDBConnection"));
//});

//var app = builder.Build();

var builder = WebApplication.CreateBuilder(args);
// Key Vault URL
var keyVaultUrl = new Uri("https://WebProject1Vault.vault.azure.net/");
// Authenticate using Managed Identity
var secretClient = new SecretClient(
    keyVaultUrl,
    new DefaultAzureCredential());
// Get secret
KeyVaultSecret secret = secretClient.GetSecret("my-first-azure-sql-server");
string connectionString = secret.Value;
// Use connection string
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
