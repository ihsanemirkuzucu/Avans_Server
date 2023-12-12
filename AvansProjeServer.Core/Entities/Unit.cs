using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansProjeServer.Core.Entities
{
    public class Unit : BaseEntity
    {
        public int UnitID { get; set; }

        public string UnitName { get; set; }

        public string UnitExplanation { get; set; }
    }
}
