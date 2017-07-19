
using SmartSql.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using Wss.WebService.Message.Request;
using Wss.WebService.Message.Response;

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
        public ResponseMessage AddsEnquiy(AddSEnquiyResponse reqMsg)
        {
            var result = new ResponseMessage();
            var iRet = 0;
            try
            {
                SqlMapper.BeginTransaction();
                
                foreach (var req in reqMsg.AddsEnquiyList)
                {
                    iRet += SqlMapper.Execute(new RequestContext()
                    {
                        SqlId = "Insert",
                        Scope = Scope,
                        Request = req
                    });
                }
                SqlMapper.CommitTransaction();
            }
            catch(Exception e)
            {
                SqlMapper.RollbackTransaction();
                result.IsSuccess = false;
                result.Msg = e.Message;
                return result;
            }
            result.IsSuccess = true;
            result.Msg = "添加数据"+ reqMsg.AddsEnquiyList.Count+",成功"+iRet+"条";
            return result;
        }

    }
}
