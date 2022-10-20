using Microsoft.EntityFrameworkCore;

namespace PicnicMicroservice.Infrastructure.Persistence.Configurations
{
    public class PicnicInvitesConfiguration : IEntityTypeConfiguration<Domain.Entities.PicnicInvite>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Domain.Entities.PicnicInvite> builder)
        {
            builder.HasKey(t => t.InviteId);

            builder.Property(t => t.PicnicId)
               .IsRequired();

            builder.Property(t => t.MemberId)
               .IsRequired();

        }
    }
}
