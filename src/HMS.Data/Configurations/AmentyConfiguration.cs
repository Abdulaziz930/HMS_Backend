using HMS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Data.Configurations
{
    public class AmentyConfiguration : IEntityTypeConfiguration<Amenty>
    {
        public void Configure(EntityTypeBuilder<Amenty> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.Icon).HasMaxLength(80).IsRequired(true);
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.UpdatedAt).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
        }
    }
}
