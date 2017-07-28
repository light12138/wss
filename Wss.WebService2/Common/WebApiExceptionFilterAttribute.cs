using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wss.DomianService;

namespace Wss.WebService2.Common
{
    public class WebApiExceptionFilterAttribute: ExceptionFilterAttribute
    {
        StudentService _sbll;
        public WebApiExceptionFilterAttribute(StudentService Sbll)
        {
            _sbll = Sbll;
        }
        public override void OnException(ExceptionContext context)
        {
           
            var message = context.Exception.Message;
            var src = context.ActionDescriptor.RouteValues["controller"] + "/"+context.ActionDescriptor.RouteValues["action"];
            var result = _sbll.AddEnquiy(new WebService.Message.Request.AddEnquiyRequest() { Name = message+"地址："+src, Age = 21, GradeId = 4, Sex = "男", CreateTime = DateTime.Now });
            
            base.OnException(context);
        }
    }
}
