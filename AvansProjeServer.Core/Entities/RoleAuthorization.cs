using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansProjeServer.Core.Entities
{
    public class RoleAuthorization : BaseEntity
    {
        public int RoleID { get; set; }

        public int AuthorizationID { get; set; }

        public int PageAuthorizationID { get; set; }

        public virtual Authorization Authorization { get; set; }

        public virtual PageAuthorization PageAuthorization { get; set; }

        public virtual Role Role { get; set; }

    }
}
