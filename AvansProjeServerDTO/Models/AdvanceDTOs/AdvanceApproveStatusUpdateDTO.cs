using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansProjeServerDTO.Models.AdvanceDTOs
{
    public record AdvanceApproveStatusUpdateDTO
    {
        public int AdvanceID { get; set; }
        public int ApproverOrRejecterID { get; set; }
        public decimal ApprovedAmount { get; set; }
        public int ApproveAdvanceStatusID { get; set; }
        public DateTime? DeterminedAdvanceDate { get; set; }
    }
}
