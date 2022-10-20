using PicnicMicroservice.Domain.Common;
using PicnicMicroservice.Domain.Entities;

namespace PicnicMicroservice.Domain.Events
{
    public class PicnicCreatedEvent : DomainEvent
    {
        public PicnicCreatedEvent(Picnic item)
        {
            Item = item;
        }

        public Picnic Item { get; }
    }
}
