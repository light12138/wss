using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Wss.WebService.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost]
       public string Index([FromBody]string msg)
        {
            return "Index";
        }
    }
}