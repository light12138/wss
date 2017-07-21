using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NLog;

namespace Wss.WebService2.Controllers
{
    [Route("[controller]/[Action]")]
    public class ValuesController : Controller
    {

        static Logger Logger = LogManager.GetCurrentClassLogger();
        // GET api/values
        [HttpGet]       
        public IEnumerable<string> Get(int i)
        {
            //HttpContext.Session.SetString("abc", "wss");
            //var name=HttpContext.Session.GetString("abc");
            return new string[] { "value1", "500" };
          
        }

        // GET api/values/5
        [HttpGet]       
        public string Get1(int a)
        {
            //var i =1/;
            try
            {
                int i = 0;
                int j = 1;
                int b = j / i;
            }catch(Exception e)
            {
                Logger.Fatal(e.Message);
            }
            return "出错了";
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
