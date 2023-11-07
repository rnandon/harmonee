namespace harmonee.Shared.Models
{
    public class FamilyEvent
    {
        public Guid Id { get; set; }
        public Guid FamilyId { get; set; }
        string Description { get; set; }
        DateTime StartTime { get; set; }
        DateTime EndTime { get; set; }
        Guid CreatedBy { get; set; }
    }
}
