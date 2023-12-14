using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansProjeServerDTO.Models.TitleDTOs
{
    public record TitleDTO
    {
        public int TitleID { get; set; }
        public string TitleName { get; set; }
    }
}
