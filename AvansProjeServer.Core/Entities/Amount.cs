using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansProjeServer.Core.Entities
{
    public class Amount : BaseEntity
    {
        public int AmountID { get; set; }

        public decimal? MinAmount { get; set; }

        public decimal? MaxAmount { get; set; }

        public DateTime? Date { get; set; }

    }
}
