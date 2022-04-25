using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MicrosoftDocs.Domain.Entities.AppUserAggregate;
using MicrosoftDocs.Domain.Entities.SectionAggregate;
using MicrosoftDocs.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDocs.Infrastructure.Data;

public class AppDbContextSeed
{
    const string adminUserName = "Admin";
    const string contributorUserName = "Adnan";
    const string normalUserName = "Mohd";
    const string articleFullTitle = "ASP.NET Core Blazor";

    public static async Task SeedAsync(AppDbContext? context,
        UserManager<AppUser>? userManager,
        RoleManager<IdentityRole>? roleManager,
        ILoggerFactory? loggerFactory)
    {
        var logger = loggerFactory?.CreateLogger<AppDbContextSeed>();

        try
        {
            if (context is null || userManager is null || roleManager is null || logger is null)
            {
                throw new ArgumentNullException(
                    nameof(context), 
                    "One of the following or more is null: context, userManager, roleManager, loggerFactory");
            }

            await context.Database.MigrateAsync();

            #region Add Users and Roles

            if (!await context.Users.AnyAsync())
            {
                // Add Roles
                if (!await context.Roles.AnyAsync())
                {
                    await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
                    await roleManager.CreateAsync(new IdentityRole(Roles.Contributor.ToString()));
                    await roleManager.CreateAsync(new IdentityRole(Roles.NormalUser.ToString()));

                    logger.LogInformation("Added Roles To Database");
                }

                // Admin user 
                var adminUser = new AppUser(adminUserName, $"{ adminUserName }@mail.co");
                await userManager.CreateAsync(adminUser, "123");
                var adminUserToken = await userManager.GenerateEmailConfirmationTokenAsync(adminUser);
                await userManager.ConfirmEmailAsync(adminUser, adminUserToken);
                await userManager.AddToRoleAsync(adminUser, Roles.Admin.ToString());

                // Contributor user 
                var contributorUser = new AppUser(contributorUserName, $"{ contributorUserName }@mail.co");
                await userManager.CreateAsync(contributorUser, "123");
                var contributorUserToken = await userManager.GenerateEmailConfirmationTokenAsync(contributorUser);
                await userManager.ConfirmEmailAsync(contributorUser, contributorUserToken);
                await userManager.AddToRoleAsync(contributorUser, Roles.Contributor.ToString());

                // Normal user 
                var normalUser = new AppUser(normalUserName, $"{ normalUserName }@mail.co");
                await userManager.CreateAsync(normalUser, "123");
                var normalUserToken = await userManager.GenerateEmailConfirmationTokenAsync(normalUser);
                await userManager.ConfirmEmailAsync(normalUser, normalUserToken);
                await userManager.AddToRoleAsync(normalUser, Roles.NormalUser.ToString());

                logger.LogInformation("Added Users To Database");
            }

            #endregion

            #region Add Sections and a Language and an Article

            if (!await context.Products.AnyAsync())
            {
                // Get Admin User
                var adminUser = await context.Users.FirstOrDefaultAsync(u => u.UserName == adminUserName);

                if (adminUser is null)
                {
                    throw new ArgumentNullException(nameof(adminUser), "Admin User Can't Be NULL");
                }

                // Create a New Language
                var language = new Language(".Net", "5.0");
                context.Languages.Add(language);

                // Create Main Product
                var mainProduct = new Product(".NET", adminUser, language);

                // Create Child Product
                var childProduct = new Product("ASP.NET Core", adminUser, language);
                mainProduct.Add(childProduct);

                adminUser.Add(mainProduct);

                // Create Section 1
                var mainSection = new Section("Web apps", adminUser, language);
                mainProduct.Add(mainSection);

                // Create Section 2
                var secondarySection = new Section("Blazor", adminUser, language);
                mainSection.Add(secondarySection);

                // Create Article 1
                var firstArticle = new Article(
                    "Overview",
                    adminUser,
                    @"
                        Welcome to Blazor!
                        Blazor is a framework for building interactive client - side web UI with.NET:

                        Create rich interactive UIs using C# instead of JavaScript.
                        Share server - side and client-side app logic written in .NET.
                        Render the UI as HTML and CSS for wide browser support, including mobile browsers.
                        Integrate with modern hosting platforms, such as Docker.
                        Build hybrid desktop and mobile apps with.NET and Blazor.

                        Using.NET for client - side web development offers the following advantages:

                        Write code in C# instead of JavaScript.
                        Leverage the existing.NET ecosystem of.NET libraries.

                        Share app logic across server and client.
                        Benefit from.NET's performance, reliability, and security.

                        Stay productive on Windows, Linux, or macOS with a development environment, such as Visual Studio or Visual Studio Code.
                        Build on a common set of languages, frameworks, and tools that are stable, feature - rich, and easy to use.
                    ",
                    "compnents;blazorserver;blazorwasm;blazorhybrid",
                    language,
                    articleFullTitle);

                secondarySection.Add(firstArticle);

                await context.SaveChangesAsync();

                logger.LogInformation("Added Sections and a Language and an Article To Database");
            }

            #endregion

            #region Add Interaction

            if (!await context.Interactions.AnyAsync())
            {
                var normalUser = await context.Users.FirstOrDefaultAsync(u => u.UserName == normalUserName);
                var article = await context.Articles.FirstOrDefaultAsync(a => a.FullTitle == articleFullTitle);

                if(normalUser is null || article is null)
                {
                    throw new ArgumentNullException(
                        nameof(normalUser), 
                        "One of the following or more is null: normalUser, article");
                }

                var interaction = new Interaction(normalUser, article, InteractionTypes.Like);
                article.AddInteraction(interaction);

                await context.SaveChangesAsync();

                logger.LogInformation("Added Interaction To Database");
            }

            #endregion

            #region Add Collection

            if (!await context.Collections.AnyAsync())
            {
                var normalUser = await context.Users.FirstOrDefaultAsync(u => u.UserName == normalUserName);
                var article = await context.Articles.FirstOrDefaultAsync(a => a.FullTitle == articleFullTitle);

                if(normalUser is null || article is null)
                {
                    throw new ArgumentNullException(
                        nameof(normalUser), 
                        "One of the following or more is null: normalUser, article");
                }

                var collection = normalUser.AddCollection("Favorites");

                collection.AddArticle(article);

                await context.SaveChangesAsync();

                logger.LogInformation("Added Interaction To Database");
            }

            #endregion

            #region Add Feedback

            if (!await context.Feedbacks.AnyAsync())
            {
                var normalUser = await context.Users.FirstOrDefaultAsync(u => u.UserName == normalUserName);
                var article = await context.Articles.FirstOrDefaultAsync(a => a.FullTitle == articleFullTitle);

                if(normalUser is null || article is null)
                {
                    throw new ArgumentNullException(
                        nameof(normalUser), 
                        "One of the following or more is null: normalUser, article");
                }

                var feedback = new Feedback("I think there is something wrong", "", normalUser, article);
                article.AddFeedback(feedback);

                await context.SaveChangesAsync();

                logger.LogInformation("Added Feedback To Database");
            }

            #endregion
        }
        catch (Exception exp)
        {
            if (logger is null) throw;

            logger.LogError(exp.Message);
        }
    }
}
