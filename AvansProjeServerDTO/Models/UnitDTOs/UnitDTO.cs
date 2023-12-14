using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansProjeServerDTO.Models.UnitDTOs
{
    public record UnitDTO
    {
        public int UnitID { get; set; }
        public string UnitName { get; set; }
    }
}
