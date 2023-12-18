using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansProjeServer.Core.Entities
{
    public class ApprovalStatus : BaseEntity
    {
        public int ApprovalStatusID { get; set; }

        public string ApprovalName { get; set; }

        public int NextApprovalStatusID { get; set; }

        public string NextApprovalName { get; set; }
    }
}
