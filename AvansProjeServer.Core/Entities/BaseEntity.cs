using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansProjeServer.Core.Entities
{
    public class BaseEntity
    {
        public bool IsActive { get; set; } = true;

        public int? ModifiedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; } = DateTime.Today;

        public int? CreatedBy { get; set; }
    }
}
