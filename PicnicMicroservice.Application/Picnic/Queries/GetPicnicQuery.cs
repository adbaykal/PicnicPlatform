using MediatR;
using PicnicMicroservice.Application.Common.Interfaces;

namespace PicnicMicroservice.Application.Picnic.Queries
{
    public class GetPicnicQuery : IRequest<Domain.Entities.Picnic?>
    {
        public Guid PicnicId { get; set; }
    }

    public class GetPicnicQueryHandler : IRequestHandler<GetPicnicQuery, Domain.Entities.Picnic?>
    {
        private readonly IApplicationDbContext _applicationDBContext;

        public GetPicnicQueryHandler(
            IApplicationDbContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }
        public async Task<Domain.Entities.Picnic?> Handle(GetPicnicQuery request, CancellationToken cancellationToken)
        {
            return await _applicationDBContext.Picnics.FindAsync(request.PicnicId);
        }
    }
}
