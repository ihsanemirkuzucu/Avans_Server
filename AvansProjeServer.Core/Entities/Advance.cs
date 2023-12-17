using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansProjeServer.Core.Entities
{
    public class Advance : BaseEntity
    {
        public int AdvanceID { get; set; }

        public int? TitleAmountApprovalRuleID { get; set; }

        public decimal? AdvanceAmount { get; set; }

        public string AdvanceExplanation { get; set; }

        public int? WorkerID { get; set; }

        public DateTime? RequestDate { get; set; }

        public DateTime? DesiredDate { get; set; }

        public bool? isApproved { get; set; }

        public int? ProjectID { get; set; }
    }
}
