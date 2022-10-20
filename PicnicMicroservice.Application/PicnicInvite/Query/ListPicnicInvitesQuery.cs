using MediatR;
using Microsoft.EntityFrameworkCore;
using PicnicMicroservice.Application.Common.Interfaces;

namespace PicnicMicroservice.Application.Picnic.Queries
{
    public class ListPicnicInvitesQuery : IRequest<List<Domain.Entities.PicnicInvite>>
    {
        public Guid PicnicId { get; set; }
    }

    public class ListPicnicInvitesQueryHandler : IRequestHandler<ListPicnicInvitesQuery, List<Domain.Entities.PicnicInvite>>
    {
        private readonly IApplicationDbContext _applicationDBContext;

        public ListPicnicInvitesQueryHandler(
            IApplicationDbContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }
        public async Task<List<Domain.Entities.PicnicInvite>> Handle(ListPicnicInvitesQuery request, CancellationToken cancellationToken)
        {
            return await _applicationDBContext.PicnicInvites.Where(x => x.PicnicId.Equals(request.PicnicId)).ToListAsync();
        }
    }
}
