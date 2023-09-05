using CP1Enterprise_EntityFramework_FIAP.Persistence;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using CP1Enterprise_EntityFramework_FIAP.Web.Entities;
using CP1Enterprise_EntityFramework_FIAP.Web.Validations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add services to the container.
builder.Services.AddDbContext<OracleDbContext>(options =>
{
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection"));
});

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddScoped<IValidator<Carta>, CartaValidator>();

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