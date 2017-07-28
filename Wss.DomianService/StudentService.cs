using SmartSql.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using Wss.DataAccess;
using Wss.WebService.Message.Request;
using Wss.WebService.Message.Response;

namespace Wss.DomianService
{
    public class StudentService
    {
        StudentDateAccess _studentService;

        ISmartSqlMapper _smartSqlMapper;

        public StudentService(StudentDateAccess acc, ISmartSqlMapper sma)
        {
            this._studentService = acc;
            this._smartSqlMapper = sma;
        }

        public ResponseMessage AddEnquiy (AddEnquiyRequest reqMsg)
        {
            var result = new ResponseMessage();
            
            try
            {
                var i = _studentService.AddEnquiy(reqMsg);
                if (i > 0)
                {
                    result.IsSuccess = true;
                    result.Msg = "添加成功";
                }
                else
                {
                    result.IsSuccess = false;
                    result.Msg = "添加失败";
                }
            }catch(Exception e)
            {
                result.IsSuccess = false;
                result.Msg = e.Message;
                return result;
            }
            return result;
        }
        public ResponseMessage EditEnquiy(EditEntityRequest reqMsg)
        {
            var result = new ResponseMessage();
            try
            {
                var i = _studentService.EditEntity(reqMsg);
                if (i > 0)
                {
                    result.IsSuccess = true;
                    result.Msg = "修改成功";
                }
                else
                {
                    result.IsSuccess = false;
                    result.Msg = "修改失败";
                }
            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Msg = e.Message;
                return result;
            }
            return result;
        }

        public ResponseMessage AddsEnquiy(AddSEnquiyResponse reqMsg)
        {
            return _studentService.AddsEnquiy(reqMsg);
        }

        public ResponseMessage Test()
        {
            int i = 0;
            int j = 1;
            int b = j / i;
            return new ResponseMessage();
        }
    }
}
