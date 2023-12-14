using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansProjeServerDTO.Models.TitleDTOs;
using AvansProjeServerDTO.Models.UnitDTOs;
using AvansProjeServerDTO.Models.WorkerDTOs;

namespace AvansProjeServerDTO.Models.AuthDTOs
{
    public record RequiredDataDTO
    {
        public List<UnitDTO> Unit { get; set; }
        public List<TitleDTO> Title { get; set; }
        public List<UpperWorkerDTO> Worker { get; set; }
    }
}
