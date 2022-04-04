using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MicrosoftDocs.Domain.Entities.SectionAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDocs.Infrastructure.Data.Configurations;

internal class LanguageConfigurations : IEntityTypeConfiguration<Language>
{
    public void Configure(EntityTypeBuilder<Language> builder)
    {
        builder.HasKey(e => e.Id);


        builder.Property(e => e.Name)
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(e => e.Version)
            .HasMaxLength(10)
            .IsRequired();
    }
}
