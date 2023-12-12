using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansProjeServer.Core.Entities
{
    public class AdvanceApproveStatus : BaseEntity
    {
        public int ApproveStatusID { get; set; }

        public int? AdvanceID { get; set; }

        public int? ApproverOrRejecterID { get; set; }

        public int? ApprovalStatusID { get; set; }

        public DateTime? Approved_DeclinedDate { get; set; }

        public decimal? ApprovedAmount { get; set; }

        public virtual Advance Advance { get; set; }

        public virtual ApprovalStatus ApprovalStatus { get; set; }

        public virtual Worker Worker { get; set; }
    }
}
