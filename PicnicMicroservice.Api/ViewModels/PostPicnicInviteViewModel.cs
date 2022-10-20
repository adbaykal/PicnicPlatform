using PicnicMicroservice.Domain.Entities;

namespace PicnicMicroservice.Api.ViewModels
{
    public class PostPicnicInviteViewModel
    {
        public string MemberId { get; set; }

        public PicnicInvite ToEntity(string picnicId)
        {
            return new PicnicInvite()
            {
                PicnicId = Guid.Parse(picnicId),
                MemberId = Guid.Parse(this.MemberId)

            };
        }
    }
}
