using System;
using System.Collections.Generic;
using System.Text;
using Wss.DataAccess.Entity;

namespace Wss.WebService.Message.Response
{
    public class QueryStudentEnquiryResponse
    {
        public QueryStudentEnquiryResponse()
        {
            StudentEnquiryList = new List<Student>();
        }
        public IList<Student> StudentEnquiryList { get; set; }
        public int Totla { get; set; }
    }
}
