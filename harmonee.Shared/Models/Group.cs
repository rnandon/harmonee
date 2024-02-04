using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace harmonee.Shared.Models;

public class Group
{
    public Guid Id { get; set; } = new Guid();
    public string Name { get; set; }
    public List<Guid> Members { get; set; } = new();
    public List<Guid> Calendar { get; set; } = new();
    public List<Guid> Lists { get; set; } = new();
}
