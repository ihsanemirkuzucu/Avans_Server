using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansProjeServer.Core.Entities
{
    public class Report : BaseEntity
    {
        public int ReportID { get; set; }

        public int? WorkerID { get; set; }

        public int? AdvanceID { get; set; }
        
        public virtual Advance Advance { get; set; }

        public virtual Worker Worker { get; set; }
    }
}
