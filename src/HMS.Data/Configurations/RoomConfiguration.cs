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
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(150).IsRequired(true);
            builder.Property(x => x.Description).HasMaxLength(500).IsRequired(true);
            builder.Property(x => x.Location).HasMaxLength(255).IsRequired(true);
            builder.Property(x => x.Price).HasColumnType("decimal(18,2)").IsRequired(true);
            builder.Property(x => x.AdultCapacity).IsRequired(true);
            builder.Property(x => x.ChildrenCapacity).HasDefaultValue(0);
            builder.Property(x => x.DiscountPercent).HasDefaultValue(0);
            builder.Property(x => x.Size).HasColumnType("decimal(18,2)").IsRequired(true);
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.UpdatedAt).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.IsFeatured).HasDefaultValue(false);
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
        }
    }
}
