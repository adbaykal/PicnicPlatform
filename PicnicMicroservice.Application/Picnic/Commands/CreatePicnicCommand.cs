using MediatR;
using PicnicMicroservice.Application.Common.Interfaces;
using PicnicMicroservice.Domain.Events;

namespace PicnicMicroservice.Application.Picnic.Commands
{
    public class CreatePicnicCommand : IRequest<Guid>
    {
        public Domain.Entities.Picnic Picnic { get; set; }
    }

    public class CreatePicnicCommandHandler : IRequestHandler<CreatePicnicCommand, Guid>
    {
        private readonly IApplicationDbContext _applicationDBContext;

        public CreatePicnicCommandHandler(IApplicationDbContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }

        public async Task<Guid> Handle(CreatePicnicCommand request, CancellationToken cancellationToken)
        {
            request.Picnic.PicnicId = Guid.NewGuid();

            request.Picnic.DomainEvents.Add(new PicnicCreatedEvent(request.Picnic));
            _applicationDBContext.Picnics.Add(request.Picnic);

            await _applicationDBContext.SaveChangesAsync(cancellationToken);

            return request.Picnic.PicnicId;
        }
    }
}
