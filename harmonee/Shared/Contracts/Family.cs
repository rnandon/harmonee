using harmonee.Shared.Auth;
using harmonee.Shared.Contracts.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace harmonee.Shared.Family
{
    public class Family : Storable
    {
        private string Name;
        private IDictionary<Guid, FamilyPermissions> Members;

        public Family()
        {
            
        }

        public string GetName()
        {
            return Name;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public IEnumerable<Guid> GetMemberIds()
        {
            return Members.Keys;
        }

        public FamilyPermissions GetUserPermissions(Guid userId)
        {
            if (!Members.TryGetValue(userId, out var permissions))
            {
                return FamilyPermissions.None;
            }
            return permissions;
        }
    }

    public enum FamilyPermissions
    {
        None,
        Read,
        Update,
        Admin
    }
}
