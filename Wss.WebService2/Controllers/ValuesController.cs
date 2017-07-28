using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NLog;
using Wss.WebService.Message.Request;
using Wss.WebService.Message.Response;
using Wss.DomianService;

namespace Wss.WebService2.Controllers
{
    [Route("api/[Action]")]
    public class ValuesController : Controller
    {
        readonly StudentService _studentService;
        static Logger Logger = LogManager.GetCurrentClassLogger();

        public ValuesController(StudentService StudentService)
        {
            _studentService = StudentService;
        }


        // GET api/values
        [HttpGet]    
        [Route("GetList")]
        public ResponseMessage Get()
        {
            //HttpContext.Session.SetString("abc", "wss");
            //var name=HttpContext.Session.GetString("abc");
            return new ResponseMessage();
          
        }

        // GET api/values/5
        [HttpGet]   
        [Route("Get1")]
        public ResponseMessage Get1(string param)
        {
            //var i =1/;
             var result= _studentService.Test();
            return result;


            //return "出错了";
             
            
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
