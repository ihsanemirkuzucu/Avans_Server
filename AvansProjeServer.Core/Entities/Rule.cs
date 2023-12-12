using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansProjeServer.Core.Entities
{
    public class Rule : BaseEntity
    {
        public int RuleID { get; set; }

        public string RuleName { get; set; }

        public DateTime? Date { get; set; }
    }
}
