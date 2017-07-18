using System;
using System.Collections.Generic;
using System.Text;
using Wss.WebService.Message.Request;

namespace Wss.DataAccess
{
    public class StudentDateAccess : SmartSql.DataAccess.DataAccess
    {
        protected override void InitScope()
        {
            this.Scope = "Student";
        }
        public StudentDateAccess(string smartSqlMapConfigPath = "SmartSqlMapConfig.xml") : base(smartSqlMapConfigPath)
        {

        }

        public AddEnquiyRequest  AddEnquiy(AddEnquiyRequest reqMsg)
        {

        }
    }
}
