using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MicrosoftDocs.Application.Notifications;
using MicrosoftDocs.Domain.Entities.AppUserAggregate;
using MicrosoftDocs.Domain.Interfaces;
using MicrosoftDocs.Infrastructure.Data;
using MediatR;
using System.Reflection;
using AutoMapper;
using MicrosoftDocs.Web.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));

builder.Services.AddIdentity<AppUser, IdentityRole>(config =>
{
    config.Password.RequireNonAlphanumeric = false;
    config.Password.RequireLowercase = false;
    config.Password.RequireUppercase = false;
    config.Password.RequireDigit = false;
    config.Password.RequiredLength = 1;
})
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllers();

builder.Services.AddTransient<IDomainEventDispatcher, MediatrDomainEventDispatcher>();


builder.Services.AddSingleton(provider => new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new MappingProfile());
}).CreateMapper());


builder.Services.AddMediatR(
    typeof(Program).Assembly,
    typeof(MediatrDomainEventDispatcher).GetTypeInfo().Assembly);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

/* Migration */
//using var scope = app.Services.CreateScope();
//var service = scope.ServiceProvider.GetRequiredService<AppDbContext>();
//service.Database.Migrate();

using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetService<AppDbContext>();
var userManager = scope.ServiceProvider.GetService<UserManager<AppUser>>();
var roleManager = scope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
await AppDbContextSeed.SeedAsync(dbContext, userManager, roleManager);


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapFallbackToFile("index.html");
});

app.Run();
