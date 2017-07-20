using System;
using System.Collections.Generic;
using System.Text;

namespace Wss.WebService.Message.Request
{
    public class AddEnquiyRequest
    {
        public string Name { get; set; }

        public int Age { get; set; }
        
        public int GradeId { get; set; } 

        public string Sex { get; set; }

        public DateTime? CreateTime { get; set; }
    }
}
