using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using PicnicMicroservice.Domain.Entities;

namespace PicnicMicroservice.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Domain.Entities.Picnic> Picnics { get; }

        DbSet<PicnicInvite> PicnicInvites { get; }

        DbSet<PicnicCollaboration> PicnicCollaborations { get; }

        DatabaseFacade Database { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
