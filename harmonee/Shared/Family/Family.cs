using harmonee.Server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace harmonee.Shared.Family
{
    public class Family : Storable
    {
        string Name;
        Guid[] FamilyMemberIds;
        Guid[] FamilyEventIds;
        Guid[] FamilyListIds;
    }
}
