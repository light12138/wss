using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wss.WebService2.Middlewares
{
    public class ExceptionMiddlewares
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddlewares(RequestDelegate Next)
        {
            _next = Next;
        }

        public Task Invoke(HttpContext context)
        {
          
                return this._next(context);          
           

        }
    }
}
