namespace Harmonee.Shared.Models;

public class Group
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid[] MemberIds { get; set; }
    public Guid[] CalendarEventIds { get; set; }
    public Guid[] GroupListIds { get; set; }
}
