using MediatR;
using Microsoft.Extensions.Logging;
using PicnicMicroservice.Application.Common.Interfaces;
using PicnicMicroservice.Application.Common.Models;
using PicnicMicroservice.Domain.Events;

namespace PicnicMicroservice.Application.Picnic.EventHandlers
{
    public class PicnicCreatedEventHandler : INotificationHandler<DomainEventNotification<PicnicCreatedEvent>>
    {
        private readonly IApplicationDbContext _applicationDBContext;
        private readonly ILogger<PicnicCreatedEventHandler> _logger;

        public PicnicCreatedEventHandler(
            IApplicationDbContext applicationDBContext,
            ILogger<PicnicCreatedEventHandler> logger)
        {
            _applicationDBContext = applicationDBContext;
            _logger = logger;
        }

        public async Task Handle(DomainEventNotification<PicnicCreatedEvent> notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Picnic has created. Starting async ops!");
            //There can be a kafka call here to throw the event to event store
        }
    }
}
