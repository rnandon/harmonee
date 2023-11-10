using harmonee.Server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace harmonee.Shared.Family
{
    public class FamilyEvent : Storable
    {
        string Description;
        DateTime StartTime;
        DateTime EndTime;
        Guid CreatedBy;
    }
}
