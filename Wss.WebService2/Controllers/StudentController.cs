using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wss.DomianService;
using Wss.WebService.Message.Request;
using Wss.WebService.Message.Response;
using Wss.DataAccess.Entity;
using SmartSql.Abstractions;
using MaiDao.Infrastructure.Message;

namespace Wss.WebService2.Controllers
{
    [Route("[controller]/[Action]")]
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
        public WebService.Message.Response.ResponseMessage AddEnquiy([FromBody]AddEnquiyRequest reqMsg)
        {
            return _studentService.AddEnquiy(reqMsg);
        }

        [HttpPost]
        public WebService.Message.Response.ResponseMessage EditEnquiy([FromBody]EditEntityRequest reqMsg)
        {
            return _studentService.EditEnquiy(reqMsg);
        }

        [HttpPost]
        public WebService.Message.Response.ResponseMessage AddsEnquiy([FromBody]AddSEnquiyResponse reqMsg)
        {
            return _studentService.AddsEnquiy(reqMsg);
        }
        #endregion

        [HttpGet]
        public ResponseMessageWrap<QueryStudentEnquiryResponse> QueryStudentEnquiry(QueryStudentEnquiryRequest reqMsg)
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