using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansProjeServer.Core.Entities
{
    public class Message : BaseEntity
    {
        public int MessageID { get; set; }

        public string MessageName { get; set; }

        public string MessageDescription { get; set; }

        public int? MessageTakerID { get; set; }

        public int? MessageSenderID { get; set; }

        public virtual Worker Worker { get; set; }

        public virtual Worker Worker1 { get; set; }
    }
}
