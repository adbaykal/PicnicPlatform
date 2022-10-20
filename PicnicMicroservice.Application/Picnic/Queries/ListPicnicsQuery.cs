using MediatR;
using Microsoft.EntityFrameworkCore;
using PicnicMicroservice.Application.Common.Interfaces;

namespace PicnicMicroservice.Application.Picnic.Queries
{
    public class ListPicnicsQuery : IRequest<List<Domain.Entities.Picnic>>
    {
    }

    public class ListPicnicsQueryHandler : IRequestHandler<ListPicnicsQuery, List<Domain.Entities.Picnic>>
    {
        private readonly IApplicationDbContext _applicationDBContext;

        public ListPicnicsQueryHandler(
            IApplicationDbContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }
        public async Task<List<Domain.Entities.Picnic>> Handle(ListPicnicsQuery request, CancellationToken cancellationToken)
        {
            return await _applicationDBContext.Picnics.ToListAsync();
        }
    }
}
