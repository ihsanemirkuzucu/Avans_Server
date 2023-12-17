using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansProjeServerDTO.Models.AdvanceDTOs
{
    public record AdvanceDetailsDTO
    {
        public AdvanceDetailDTO AdvanceDetail { get; set; }
        public List<AdvanceHistoryDTO> AdvanceHistoryList { get; set; }
    }
}
