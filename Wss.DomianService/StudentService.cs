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

        public StudentService(StudentDateAccess acc)
        {
            this._studentService = acc;
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
    }
}
