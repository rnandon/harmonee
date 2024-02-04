using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace harmonee.Shared.Models;

public class CalendarEvent
{
    public Guid Id { get; set; }
    public Guid GroupId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public Guid Creator { get; set; }
    public List<Guid> Attendees { get; set; }
}
