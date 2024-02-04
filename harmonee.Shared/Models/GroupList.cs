using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace harmonee.Shared.Models;

public class GroupList
{
	public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid Creator { get; set; }
    public List<ListItem> Items { get; set; }
    public bool IsChecklist { get; set; }
}

public class ListItem
{
    public string Value { get; set; }
    public bool Completed { get; set; }
}
