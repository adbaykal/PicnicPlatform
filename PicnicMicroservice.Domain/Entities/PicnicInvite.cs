namespace PicnicMicroservice.Domain.Entities
{
    public class PicnicInvite
    {
        public Guid InviteId { get; set; }
        public Guid PicnicId { get; set; }
        public Guid MemberId { get; set; }
    }
}
