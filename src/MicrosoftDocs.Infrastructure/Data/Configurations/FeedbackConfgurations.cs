using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MicrosoftDocs.Domain.Entities.SectionAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDocs.Infrastructure.Data.Configurations;

internal class FeedbackConfgurations : IEntityTypeConfiguration<Feedback>
{
    public void Configure(EntityTypeBuilder<Feedback> builder)
    {
        builder.HasKey(e => e.Id);


        builder.Property(e => e.Title)
            .HasMaxLength(60)
            .IsRequired();

        builder.Property(e => e.Content)
            .IsRequired();
    }
}
