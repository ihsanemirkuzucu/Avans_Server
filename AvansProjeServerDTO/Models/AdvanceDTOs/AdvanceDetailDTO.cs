using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansProjeServerDTO.Models.AdvanceDTOs
{
    public record AdvanceDetailDTO
    {
        public DateTime? RequestDate { get; set; }
        public DateTime? DesiredDate { get; set; }
        public string ProjectName { get; set; }
        public string AdvanceExplanation { get; set; }
        public decimal AdvanceAmount { get; set; }
        public decimal ApprovedAmount { get; set; }
        public string ApprovalName { get; set; }
        public string ReceiptNo { get; set; }
        public bool? PaybackStatus { get; set; }
    }
}
