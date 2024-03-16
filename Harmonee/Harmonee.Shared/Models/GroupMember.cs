using Harmonee.Shared.Utilities;

namespace Harmonee.Shared.Models;

public class GroupMember
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid GroupId { get; set; }
    public Guid UserId { get; set; }
    public PermissionTypes PermissionType { get; set; }
}
