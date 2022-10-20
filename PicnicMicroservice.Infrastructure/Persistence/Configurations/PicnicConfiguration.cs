using Microsoft.EntityFrameworkCore;

namespace PicnicMicroservice.Infrastructure.Persistence.Configurations
{
    public class PicnicConfiguration : IEntityTypeConfiguration<Domain.Entities.Picnic>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Domain.Entities.Picnic> builder)
        {
            builder.Ignore(t => t.DomainEvents);

            builder.HasKey(t => t.PicnicId);

            builder.Property(t => t.MemberId)
               .IsRequired();

            builder.Property(t => t.Description)
                .HasMaxLength(100);

            builder.Property(t => t.LocationLat)
                .HasColumnType("decimal(8,6)");
            builder.Property(t => t.LocationLong)
                .HasColumnType("decimal(9,6)");

            builder.Property(t => t.PicnicType)
                .HasColumnType("smallint");
        }
    }
}
