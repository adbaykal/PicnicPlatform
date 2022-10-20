using Microsoft.EntityFrameworkCore;

namespace PicnicMicroservice.Infrastructure.Persistence.Configurations
{
    internal class PicnicCollaborationConfiguration : IEntityTypeConfiguration<Domain.Entities.PicnicCollaboration>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Domain.Entities.PicnicCollaboration> builder)
        {
            builder.HasKey(t => t.CollaborationId);

            builder.Property(t => t.InviteId)
               .IsRequired();

            builder.Property(t => t.Description)
               .HasMaxLength(100);

        }
    }
}
