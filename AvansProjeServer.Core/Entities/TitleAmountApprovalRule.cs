using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansProjeServer.Core.Entities
{
    public class TitleAmountApprovalRule : BaseEntity
    {
        public int ID { get; set; }

        public int? AmountID { get; set; }

        public DateTime? Date { get; set; }

        public int? TitleID { get; set; }

        public virtual Amount Amount { get; set; }

        public virtual Title Title { get; set; }
    }
}
