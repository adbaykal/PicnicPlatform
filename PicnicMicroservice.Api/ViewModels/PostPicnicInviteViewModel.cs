using PicnicMicroservice.Domain.Entities;

namespace PicnicMicroservice.Api.ViewModels
{
    public class PostPicnicInviteViewModel
    {
        public string PicnicId { get; set; }
        public string MemberId { get; set; }

        public PicnicInvite ToEntity()
        {
            return new PicnicInvite()
            {
                MemberId = Guid.Parse(this.MemberId),
                PicnicId = Guid.Parse(this.PicnicId)
            };
        }
    }
}
