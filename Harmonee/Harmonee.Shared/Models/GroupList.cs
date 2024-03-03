namespace Harmonee.Shared.Models;

public class GroupList
{
    public Guid Id { get; set; }
    public Guid GroupId { get; set; }
    public ListItem[] Items { get; set; }
}
