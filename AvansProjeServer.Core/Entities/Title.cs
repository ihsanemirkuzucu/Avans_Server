using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansProjeServer.Core.Entities
{
    public class Title : BaseEntity
    {
        public int TitleID { get; set; }

        public string TitleName { get; set; }

        public string TitleDescription { get; set; }

        public int? RoleID { get; set; }

        public virtual Role Role { get; set; }
    }
}
