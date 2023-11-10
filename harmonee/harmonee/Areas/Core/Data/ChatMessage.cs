namespace harmonee.Areas.Core.Data
{
    public class ChatMessage
    {
        public Guid Id { get; set; }
        public Guid ChatId { get; set; }
        public Guid SourceUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Contents { get; set; }
        public Guid? ImageId { get; set; }
    }
}
