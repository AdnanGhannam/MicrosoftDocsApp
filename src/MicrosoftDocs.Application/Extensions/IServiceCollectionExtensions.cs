using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MicrosoftDocs.Application.AppRequirements;
using MicrosoftDocs.Domain.Constants;
using MicrosoftDocs.Domain.Entities.AppUserAggregate;
using MicrosoftDocs.Domain.Enums;
using MicrosoftDocs.Domain.Interfaces;
using MicrosoftDocs.Infrastructure.Data;
using MicrosoftDocs.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDocs.Application.Extensions;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddSqlServer<T>(this IServiceCollection services, string connectionString)
        where T : DbContext
    {
        services.AddDbContext<T>(options =>
        {
            options.UseSqlServer(connectionString)
                    .EnableSensitiveDataLogging();
        });

        return services;
    }

    public static IServiceCollection AddConfiguredControllers(this IServiceCollection services)
    {
        services.AddControllers().ConfigureApiBehaviorOptions(config =>
        {
            config.InvalidModelStateResponseFactory = context =>
            {
                var response = new ResponseModel();

                foreach (var item in context.ModelState)
                {
                    response.Errors.Add(new(item.Key, item.Value.Errors.FirstOrDefault()?.ErrorMessage));
                }

                var results = new ObjectResult(response);

                return results;
            };
        });

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient(typeof(IEfRepository<>), typeof(EfRepository<>));
        return services;
    }

    public static IServiceCollection AddMappingProfiles(this IServiceCollection services, params Profile[] profiles)
    {
        services.AddSingleton(provider => new MapperConfiguration(cfg =>
        {
            cfg.AddProfiles(profiles);
        }).CreateMapper());

        return services;
    }

    public static IServiceCollection AddConfiguredIdentity<T>(this IServiceCollection services)
        where T : DbContext
    {
        services.AddIdentity<AppUser, IdentityRole>(config =>
        {
            config.Password.RequireNonAlphanumeric = false;
            config.Password.RequireLowercase = false;
            config.Password.RequireUppercase = false;
            config.Password.RequireDigit = false;
            config.Password.RequiredLength = 1;

            config.SignIn.RequireConfirmedEmail = true;
        })
            .AddEntityFrameworkStores<T>()
            .AddDefaultTokenProviders();

        return services;
    }

    public static IServiceCollection AddCookieConfigurations(this IServiceCollection services)
    {
        services.ConfigureApplicationCookie(config =>
        {
            config.Cookie.Name = "MicrosoftDocsCookie";

            config.Events = new CookieAuthenticationEvents
            {
                OnRedirectToLogin = context =>
                {
                    context.Response.StatusCode = 401;
                    return Task.CompletedTask;
                },

                OnRedirectToAccessDenied = context =>
                {
                    context.Response.StatusCode = 403;
                    return Task.CompletedTask;
                },
            };
        });

        return services;
    }

    public static IServiceCollection ConfigureAuthorization(this IServiceCollection services)
    {
        services.AddAuthorization(config =>
        {
            config.AddPolicy(PoliciesConstants.AdminPolicy, policyBuilder =>
            {
                policyBuilder.RequireRole(Roles.Admin.ToString());
            });

            config.AddPolicy(PoliciesConstants.ContributorPolicy, policyBuilder =>
            {
                policyBuilder.RequireRole(Roles.Admin.ToString(),
                    Roles.Contributor.ToString());
            });

            config.AddPolicy(PoliciesConstants.NormalUserPolicy, policyBuilder =>
            {
                policyBuilder.RequireRole(Roles.Admin.ToString(),
                    Roles.Contributor.ToString(),
                    Roles.NormalUser.ToString());
            });

            config.AddPolicy(PoliciesConstants.ContributorEdit, policyBuilder =>
            {
                policyBuilder.AddRequirements(new IsContributorRequirement());
            });
        });

        services.AddSingleton<IAuthorizationHandler, IsContributorRequirementHandler>();

        return services;
    }
}
