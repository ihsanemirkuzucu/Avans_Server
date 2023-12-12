using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansProjeServer.Core.Entities
{
    public class Role : BaseEntity
    {
        public int RoleID { get; set; }

        public string RoleName { get; set; }
    }
}
