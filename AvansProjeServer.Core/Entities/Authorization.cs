using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansProjeServer.Core.Entities
{
    public class Authorization : BaseEntity
    {
        public int AuthorizationID { get; set; }

        public string AutherizationPath { get; set; }
    }
}
