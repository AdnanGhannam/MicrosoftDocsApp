using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MicrosoftDocs.Application.Notifications;
using MicrosoftDocs.Domain.Entities.AppUserAggregate;
using MicrosoftDocs.Domain.Interfaces;
using MicrosoftDocs.Infrastructure.Data;
using MediatR;
using System.Reflection;
using MicrosoftDocs.Application.Extensions;
using MicrosoftDocs.Application.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddSqlServer<AppDbContext>(builder.Configuration.GetConnectionString("DbConnection"))
    .AddConfiguredIdentity<AppDbContext>()
    .AddMappingProfiles(new MappingProfile())
    .AddConfiguredControllers()
    .AddTransient<IDomainEventDispatcher, MediatrDomainEventDispatcher>()
    .AddMediatR(typeof(Program).Assembly, typeof(MediatrDomainEventDispatcher).GetTypeInfo().Assembly)
    .AddEndpointsApiExplorer()
    .AddSwaggerGen();




var app = builder.Build();

// Seed
using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetService<AppDbContext>();
var userManager = scope.ServiceProvider.GetService<UserManager<AppUser>>();
var roleManager = scope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
var logger = scope.ServiceProvider.GetService<ILoggerFactory>();

await AppDbContextSeed.SeedAsync(dbContext, userManager, roleManager, logger);


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles()
    .UseStaticFiles();

app.UseRouting();

app.UseAuthentication()
    .UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapFallbackToFile("index.html");
});

app.Run();
