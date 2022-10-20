using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace PicnicMicroservice.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Domain.Entities.Picnic> Picnics { get; }

        DbSet<Domain.Entities.PicnicInvite> PicnicInvites { get; }

        DbSet<Domain.Entities.PicnicCollaboration> PicnicCollaborations { get; }

        DatabaseFacade Database { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
