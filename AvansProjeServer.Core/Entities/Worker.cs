using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansProjeServer.Core.Entities
{
    public class Worker : BaseEntity
    {
        public int WorkerID { get; set; }

        public string WorkerName { get; set; }

        public string WorkerEmail { get; set; }

        public string WorkerPhonenumber { get; set; }

        public int? UnitID { get; set; }

        public int? TitleID { get; set; }

        public int? UpperWorkerID { get; set; }

        public byte[] PasswordSalt { get; set; }

        public byte[] PasswordHash { get; set; }

        public virtual Title Title { get; set; }

        public virtual Unit Unit { get; set; }

        public virtual Worker Worker2 { get; set; }
    }
}
