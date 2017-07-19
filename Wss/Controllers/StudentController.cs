using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartSql.Abstractions;
using Wss.DomianService;
using Wss.WebService.Message.Request;
using Wss.WebService.Message.Response;
using MaiDao.Infrastructure.Message;
using Wss.DataAccess.Entity;

namespace Wss.WebService.Controllers
{
    public class StudentController : Controller
    {

        readonly ISmartSqlMapper _smartSqlMapper;

        readonly StudentService _studentService;

        public StudentController(ISmartSqlMapper smartSqlMapper, StudentService StudentService)
        {
            _smartSqlMapper = smartSqlMapper;
            _studentService = StudentService;
        }

        #region Command

        [HttpPost]
        public Message.Response.ResponseMessage AddEnquiy([FromBody]AddEnquiyRequest reqMsg)
        {
            return _studentService.AddEnquiy(reqMsg);
        }

        [HttpPost]
        public Message.Response.ResponseMessage EditEnquiy([FromBody]EditEntityRequest reqMsg)
        {
            return _studentService.EditEnquiy(reqMsg);
        } 
        #endregion

        [HttpPost]
        public ResponseMessageWrap<QueryStudentEnquiryResponse> QueryStudentEnquiry([FromBody]QueryStudentEnquiryRequest reqMsg)
        {
            var list = _smartSqlMapper.Query<Student>(new RequestContext()
            {
                SqlId = "Select",
                Scope = "T_Student",
                Request = reqMsg
            });
            var totla = _smartSqlMapper.ExecuteScalar<int>(new RequestContext()
            {
                SqlId = "Count",
                Scope = "T_Student",
                Request = reqMsg
            });
            return new ResponseMessageWrap<QueryStudentEnquiryResponse>()
            {
                Body = new QueryStudentEnquiryResponse()
                {
                    StudentEnquiryList = list.ToList(),
                    Totla = totla
                    
                }
            };

        }

        [HttpPost]
        public ResponseMessageWrap<GetEntityByIdResponse> GetEntityById(GetByIdRequest<string> reqMsg)
        {
            var entity = _smartSqlMapper.QuerySingle<Student>(new RequestContext()
            {
                Scope = "T_Student",
                SqlId = "GetEntity",
                Request = reqMsg
            });
            return new ResponseMessageWrap<GetEntityByIdResponse>()
            {
                Body = new GetEntityByIdResponse()
                {
                    Stu = entity
                }
            };
        }
    }
}