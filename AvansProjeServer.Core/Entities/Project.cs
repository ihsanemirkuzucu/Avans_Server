using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansProjeServer.Core.Entities
{
    public class Project : BaseEntity
    {
        public int ProjectID { get; set; }

        public string ProjectName { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string ProjectExplanation { get; set; }
    }
}
