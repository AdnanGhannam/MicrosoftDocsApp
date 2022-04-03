using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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

        builder.Property(e => e.Title)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(e => e.FullTitle)
            .HasMaxLength(40);

        builder.Property(e => e.Content)
            .IsRequired();

        builder.Property(e => e.CreatorId)
            .IsRequired();


        builder.HasMany(e => e.Feedbacks)
            .WithOne(e => e.Article)
            .HasForeignKey(e => e.ArticleId);


        builder.HasMany(e => e.Interactions)
            .WithOne(e => e.Article)
            .HasForeignKey(e => e.ArticleId);
    }
}
