using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MicrosoftDocs.Domain.Entities.AppUserAggregate;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDocs.Infrastructure.Data.Configurations;

internal class CollectionConfigurations : IEntityTypeConfiguration<Collection>
{
    public void Configure(EntityTypeBuilder<Collection> builder)
    {
        builder.HasKey(e => e.Id);


        builder.Property(e => e.Name)
            .HasMaxLength(50)
            .IsRequired();
    }
}
