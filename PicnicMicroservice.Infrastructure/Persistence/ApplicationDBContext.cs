using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using PicnicMicroservice.Application.Common.Interfaces;
using PicnicMicroservice.Domain.Common;
using PicnicMicroservice.Domain.Entities;
using System.Reflection;

namespace PicnicMicroservice.Infrastructure.Persistence
{
    public class ApplicationDBContext : DbContext, IApplicationDbContext
    {
        private readonly IDomainEventService _domainEventService;

        public ApplicationDBContext(
            IDomainEventService domainEventService,
            DbContextOptions<ApplicationDBContext> options) : base(options)
        {
            _domainEventService = domainEventService;
        }

        public DbSet<Domain.Entities.Picnic> Picnics => Set<Domain.Entities.Picnic>();

        public DbSet<PicnicInvite> PicnicInvites => Set<PicnicInvite>();

        public DbSet<PicnicCollaboration> PicnicCollaborations => Set<PicnicCollaboration>();

        DatabaseFacade IApplicationDbContext.Database
        {
            get => base.Database;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {

            var events = ChangeTracker.Entries<IHasDomainEvent>()
               .Select(x => x.Entity.DomainEvents)
               .SelectMany(x => x)
               .Where(domainEvent => !domainEvent.IsPublished)
               .ToArray();

            var result = await base.SaveChangesAsync(cancellationToken);

            await DispatchEvents(events);

            return result;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        private async Task DispatchEvents(DomainEvent[] events)
        {
            foreach (var @event in events)
            {
                @event.IsPublished = true;
                await _domainEventService.Publish(@event);
            }
        }
    }
}
