using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MicrosoftDocs.Domain.Entities.SectionAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDocs.Infrastructure.Data.Configurations;

internal class SectionConfigurations : IEntityTypeConfiguration<Section>
{
    public void Configure(EntityTypeBuilder<Section> builder)
    {
        builder.HasKey(e => e.Id);


        builder.Property(e => e.Title)
            .IsRequired()
            .HasMaxLength(20);


        builder.HasOne(e => e.Language)
            .WithMany(e => e.Sections)
            .HasForeignKey(e => e.LanguageId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(e => e.Sections)
            .WithOne();
    }
}
