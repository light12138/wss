using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wss.TestWeb.Model;
using Microsoft.AspNetCore.Routing;

namespace Wss.TestWeb.DBContextModel
{
    
    public class EFModelsController : Controller
    {
        Sqlcontest _sqlContest;
        public EFModelsController(Sqlcontest Sql)
        {
            this._sqlContest = Sql;
        }
        [HttpGet]
        public string Index()
        {
            T_Test t = new T_Test() { Id = 1, Name = "wss" };
            _sqlContest.Add(t);
            _sqlContest.SaveChanges();
            return "View()";
        }
    }

    public class ApiAuthorizedOptions
    {
        //public string Name { get; set; }

        public string EncryptKey { get; set; }

        public int ExpiredSecond { get; set; }
    }
}