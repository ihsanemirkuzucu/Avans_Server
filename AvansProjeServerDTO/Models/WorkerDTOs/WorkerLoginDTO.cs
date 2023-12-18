using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansProjeServerDTO.Models.WorkerDTOs
{
    public record WorkerLoginDTO
    {
        public int WorkerID { get; set; }
        public string WorkerEmail { get; set; }
        public string WorkerName { get; set; }
        public string Password { get; set; }
        public int TitleID { get; set; }
        public string TitleName { get; set; }
        public string Token { get; set; }
    }
}
