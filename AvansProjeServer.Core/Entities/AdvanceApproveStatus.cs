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

        public int NextApproverID { get; set; }

        public bool IsReview { get; set; }

        public DateTime? DeterminedAdvanceDate { get; set; }

        public DateTime? PaymentDate { get; set; }
    }
}
