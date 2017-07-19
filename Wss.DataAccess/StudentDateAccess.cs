using SmartSql.Abstractions;
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
            this.Scope = "T_Student";
        }
        public StudentDateAccess(string smartSqlMapConfigPath = "SmartSqlMapConfig.xml") : base(smartSqlMapConfigPath)
        {

        }

        public int  AddEnquiy(AddEnquiyRequest reqMsg)
        {
            var iRet = SqlMapper.Execute(new RequestContext()
            {
                SqlId = "Insert",
                Scope = Scope,
                Request = reqMsg
            });
            return iRet; 
        }
        public int EditEntity(EditEntityRequest reqMsg)
        {
            var iRet = SqlMapper.ExecuteScalar<int>(new RequestContext()
            {
                SqlId = "Update",
                Scope = Scope,
                Request = reqMsg
            });
            return iRet;
        }
        //public 

    }
}
