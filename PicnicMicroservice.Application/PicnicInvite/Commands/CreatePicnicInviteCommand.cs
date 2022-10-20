using MediatR;
using PicnicMicroservice.Application.Common.Interfaces;

namespace PicnicMicroservice.Application.PicnicInvite.Commands
{
    public class CreatePicnicInviteCommand : IRequest<Guid>
    {
        public Domain.Entities.PicnicInvite Invite { get; set; }
    }

    public class CreatePicnicInviteCommandHandler : IRequestHandler<CreatePicnicInviteCommand, Guid>
    {
        private readonly IApplicationDbContext _applicationDBContext;

        public CreatePicnicInviteCommandHandler(IApplicationDbContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }

        public async Task<Guid> Handle(CreatePicnicInviteCommand request, CancellationToken cancellationToken)
        {
            if (request == null || request.Invite == null)
            {
                throw new ArgumentOutOfRangeException(nameof(request));
            }

            var picnic = await _applicationDBContext.Picnics.FindAsync(new object?[] { request.Invite.PicnicId }, cancellationToken: cancellationToken);

            if (picnic == null)
            {
                throw new KeyNotFoundException(request.Invite.PicnicId.ToString());
            }

            await _applicationDBContext.PicnicInvites.AddAsync(request.Invite, cancellationToken);

            await _applicationDBContext.SaveChangesAsync(cancellationToken);

            return request.Invite.PicnicId;
        }
    }
}
