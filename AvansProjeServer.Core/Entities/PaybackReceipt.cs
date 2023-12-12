using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansProjeServer.Core.Entities
{
    public class PaybackReceipt : BaseEntity
    {
        public int PaybackReceiptID { get; set; }

        public DateTime? ReceiptDate { get; set; }

        public string ReceiptDescription { get; set; }
    }
}
