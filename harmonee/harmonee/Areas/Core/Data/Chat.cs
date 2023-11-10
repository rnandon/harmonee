using harmonee.Areas.Identity.Data;

namespace harmonee.Areas.Core.Data
{
    public class Chat
    {
        public Guid Id { get; set; }
        public List<User> Users { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
