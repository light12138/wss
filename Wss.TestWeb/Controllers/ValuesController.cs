using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System.IO;
using System.Text;
using Microsoft.Extensions.Primitives;

namespace Wss.TestWeb.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        IFileProvider _fileProvider;
        public ValuesController(IFileProvider FileProvider)
        {
            _fileProvider = FileProvider;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var ss = "1133";
            //byte[] buffer;
            //using (Stream readStream = this._fileProvider.GetFileInfo(@"\wss\wss\Wss.TestWeb\wwwroot\bat.txt").CreateReadStream())
            //// using (StreamReader readStream = new StreamReader()
            //{
            //    buffer = new byte[readStream.Length];
            //    readStream.ReadAsync(buffer, 0, buffer.Length);
            //}
            //ss = Encoding.UTF8.GetString(buffer);
            //IFileProvider fileProvider = new PhysicalFileProvider(@"c:\test");
            ChangeToken.OnChange(() => _fileProvider.Watch("\bat.txt"), () => LoadFileAsync(_fileProvider));
            while (true)
            {
                System.IO.File.WriteAllText(@"D:\exercise\wss\wss\Wss.TestWeb\wwwroot\bat.txt", DateTime.Now.ToString());
                Task.Delay(5000).Wait();
            }
            return new string[] { "value1", ss };
        }

        public static async void LoadFileAsync(IFileProvider fileProvider)
        {
            Stream stream = fileProvider.GetFileInfo("data.txt").CreateReadStream();
            {
                byte[] buffer = new byte[stream.Length];
                await stream.ReadAsync(buffer, 0, buffer.Length);
                Console.WriteLine(Encoding.ASCII.GetString(buffer));
            }
        }



        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
