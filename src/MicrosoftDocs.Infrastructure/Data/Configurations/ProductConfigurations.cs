using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MicrosoftDocs.Domain.Entities.SectionAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDocs.Infrastructure.Data.Configurations;

internal class ProductConfigurations : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(e => e.Id);


        builder.Property(e => e.Title)
            .IsRequired()
            .HasMaxLength(20);


        builder.HasOne(e => e.Language)
            .WithMany(e => e.Products)
            .HasForeignKey(e => e.LanguageId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(e => e.Products)
            .WithOne()
            .HasForeignKey(e => e.ParentId);

        builder.HasMany(e => e.Sections)
            .WithOne();

        builder.HasMany(e => e.Articles)
            .WithOne();
    }
}
