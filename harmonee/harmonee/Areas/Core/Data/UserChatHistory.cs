namespace harmonee.Areas.Core.Data
{
    public class UserChatHistory
    {
        public Guid UserId { get; set; }
        public Guid ChatId { get; set; }
        public DateTime LastViewed { get; set; }
    }
}
