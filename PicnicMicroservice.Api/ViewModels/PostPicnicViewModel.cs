using PicnicMicroservice.Domain.Entities;
using PicnicMicroservice.Domain.Enums;

namespace PicnicMicroservice.Api.ViewModels
{
    public class PostPicnicViewModel
    {
        public string MemberId { get; set; }

        public string? Description { get; set; }

        public decimal LocationLat { get; set; }

        public decimal LocationLong { get; set; }

        public PicnicType PicnicType { get; set; }

        public Picnic ToEntity()
        {
            return new Picnic()
            {
                MemberId = Guid.Parse(this.MemberId),
                Description = this.Description,
                PicnicType = this.PicnicType,
                LocationLat = this.LocationLat,
                LocationLong = this.LocationLong
            };
        }
    }
}
