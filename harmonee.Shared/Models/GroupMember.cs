using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace harmonee.Shared.Models;

public class GroupMember
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid GroupId { get; set; }
    public Guid UserId { get; set; }
}
