using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansProjeServer.Core.Entities
{
    public class Worker : BaseEntity
    {
        [Key]
        public int WorkerID { get; set; }

        public string WorkerName { get; set; }

        public string WorkerEmail { get; set; }

        public string WorkerPhonenumber { get; set; }

        public int? UnitID { get; set; }

        public int? TitleID { get; set; }

        public int? UpperWorkerID { get; set; }

        public byte[] PasswordSalt { get; set; }

        public byte[] PasswordHash { get; set; }

        public Title Title { get; set; }

        public Unit Unit { get; set; }

        public Worker Worker2 { get; set; }
    }
}
