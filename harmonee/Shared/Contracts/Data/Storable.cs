using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace harmonee.Shared.Contracts.Data
{
    public abstract class Storable
    {
        private Guid Id;
        private UserDate Created;
        private UserDate Updated;

        public virtual Guid GetId()
        {
            return Id;
        }

        public virtual UserDate GetCreated()
        {
            return Created;
        }

        public virtual UserDate GetUpdated()
        {
            return Updated;
        }

        public virtual void SetUpdated(UserDate newUpdate)
        {
            Updated = newUpdate;
        }
    }

    public class UserDate
    {
        private Guid UserId;
        private DateTime Date;
    }
}
