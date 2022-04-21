using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MicrosoftDocs.Domain.Entities.AppUserAggregate;
using MicrosoftDocs.Domain.Entities.SectionAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDocs.Infrastructure.Data.Configurations;

internal class AppUserConfigurations : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.HasKey(e => e.Id);


        builder.HasMany(e => e.Collections)
            .WithOne(e => e.Owner)
            .HasForeignKey(e => e.OwnerId);


        builder.HasMany(e => e.Products)
            .WithOne(e => e.Creator)
            .HasForeignKey(e => e.CreatorId);


        builder.HasMany(e => e.Sections)
            .WithOne(e => e.Creator)
            .HasForeignKey(e => e.CreatorId);


        builder.HasMany(e => e.OwnedArticles)
            .WithOne(e => e.Creator)
            .HasForeignKey(e => e.CreatorId);


        builder.HasMany(e => e.Articles)
            .WithMany(e => e.Contributors)
            .UsingEntity<Dictionary<string, object>>(
                "ContributorsArticles",
                e => e.HasOne<Article>().WithMany().OnDelete(DeleteBehavior.NoAction),
                e => e.HasOne<AppUser>().WithMany().OnDelete(DeleteBehavior.NoAction));


        builder.HasMany(e => e.Interactions)
            .WithOne(e => e.Interactor)
            .HasForeignKey(e => e.InteractorId)
            .OnDelete(DeleteBehavior.NoAction);


        builder.HasMany(e => e.Feedbacks)
            .WithOne(e => e.User)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
