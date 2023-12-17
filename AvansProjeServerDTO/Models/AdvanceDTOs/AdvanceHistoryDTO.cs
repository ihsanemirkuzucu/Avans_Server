using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansProjeServerDTO.Models.AdvanceDTOs
{
    public record AdvanceHistoryDTO
    {
        public string ApprovalName { get; set; }
        public DateTime? ApprovedDeclinedDate { get; set; }
        public string ApprovedDeclinedName { get; set; }
        public string NextApprovedDeclinedName { get; set; }
        public string NextApprovalName { get; set; }
        public decimal ApprovedAmount { get; set; }
        public DateTime? PaybackDate { get; set; }
    }
}
