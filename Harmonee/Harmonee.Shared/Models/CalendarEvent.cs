namespace Harmonee.Shared.Models;

public class CalendarEvent
{
    public Guid Id { get; set; }
    public Guid GroupId { get; set; }
    public string Name { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public Guid CreatedBy { get; set; }
    public Guid[] Invitees { get; set; }
    public Guid[] Attendees { get; set; }
}
