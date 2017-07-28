using System;
using System.Collections.Generic;
using System.Text;
using Wss.WebService.Message.Attribute;

namespace Wss.WebService.Message.Request
{
    public class AddEnquiyRequest
    {
        public string Name { get; set; }

        public int Age { get; set; }
        
        public int GradeId { get; set; } 

        public string Sex { get; set; }

        public DateTime? CreateTime { get; set; }

      //  [Domain("M",ErrorMessageResourceName = "AddEnquiyRequest", ErrorMessageResourceType =typeof(string))]
        public string Gender { get; set; }
    }
}
