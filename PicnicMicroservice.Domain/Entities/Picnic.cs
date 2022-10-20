using PicnicMicroservice.Domain.Common;
using PicnicMicroservice.Domain.Enums;

namespace PicnicMicroservice.Domain.Entities
{
    public class Picnic
    {
        public Guid PicnicId { get; set; }
        public Guid MemberId { get; set; }

        public string? Description { get; set; }

        public decimal LocationLat { get; set; }

        public decimal LocationLong { get; set; }

        public PicnicType PicnicType { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
