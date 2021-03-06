using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Schronisko.Areas.Identity.Data;
using Schronisko.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("SchroniskoContextConnection") ?? throw new InvalidOperationException("Connection string 'SchroniskoContextConnection' not found.");

builder.Services.AddDbContext<global::Schronisko.Data.SchroniskoContext>((global::Microsoft.EntityFrameworkCore.DbContextOptionsBuilder options) =>
    options.UseSqlServer(connectionString));;
builder.Services.AddDbContext<global::Schronisko.Areas.Identity.Data.SchroniskoContext>((global::Microsoft.EntityFrameworkCore.DbContextOptionsBuilder options) =>
    options.UseSqlServer(connectionString));;
builder.Services.AddDefaultIdentity<SchroniskoUsers>((IdentityOptions options) => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<Schronisko.Data.SchroniskoContext>();;

// Add services to the container.
builder.Services.AddRazorPages();

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
