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

internal class ArticleConfigurations : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(e => e.FullTitle)
            .HasMaxLength(40);

        builder.Property(e => e.Content)
            .IsRequired();


        builder.HasOne(e => e.Language)
            .WithMany(e => e.Articles)
            .HasForeignKey(e => e.LanguageId)
            .OnDelete(DeleteBehavior.NoAction);


        builder.HasMany(e => e.Feedbacks)
            .WithOne(e => e.Article)
            .HasForeignKey(e => e.ArticleId);


        builder.HasMany(e => e.Interactions)
            .WithOne(e => e.Article)
            .HasForeignKey(e => e.ArticleId);

        builder.HasMany(e => e.SavedIn)
            .WithMany(e => e.Articles)
            .UsingEntity<Dictionary<string, object>>(
                "CollectionsArticles",
                e => e.HasOne<Collection>().WithMany().OnDelete(DeleteBehavior.NoAction),
                e => e.HasOne<Article>().WithMany().OnDelete(DeleteBehavior.NoAction));
    }
}
