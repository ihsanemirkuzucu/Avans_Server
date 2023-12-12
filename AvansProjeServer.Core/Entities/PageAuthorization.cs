using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansProjeServer.Core.Entities
{
    public class PageAuthorization : BaseEntity
    {
        public int PageAuthorizationID { get; set; }

        public string PageAuthrizationName { get; set; }

        public string PageAuthorizationPath { get; set; }
    }
}
