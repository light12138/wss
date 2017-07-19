using MaiDao.Infrastructure.Message;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wss.WebService.Message.Request
{
    public class QueryStudentEnquiryRequest: RequestMessage
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int GradeId { get; set; }

        public int PageIndex { get; set; } = 1;

        public int PageSize { get; set; } = 10;
    }
}
