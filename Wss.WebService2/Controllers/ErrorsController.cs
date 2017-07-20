using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Wss.WebService2.Controllers
{
    public class ErrorsController : Controller
    {
        [Route("Error")]
        [HttpGet]
        public string CustomError()
        {
           
            return "³ö´íÀ²~~~~";
        }
    }
}