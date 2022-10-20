

using PicnicMicroservice.Domain.Common;

namespace PicnicMicroservice.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
