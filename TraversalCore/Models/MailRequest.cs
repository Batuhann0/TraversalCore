using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCore.Models
{
    public class MailRequest
    {
        public string Name { get; set; }
        public string SenderMail { get; set; }
        public string RecevierMail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
