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
using System.Net.Http;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace Wss.WebService2.Controllers
{
    [Route("[controller]/[Action]")]
    public class StudentController : Controller
    {

        readonly ISmartSqlMapper _smartSqlMapper;

        readonly StudentService _studentService;
        private readonly ILogger<StudentController> _logger;


        public StudentController(ISmartSqlMapper smartSqlMapper, StudentService StudentService, ILogger<StudentController> logger)
        {
            _smartSqlMapper = smartSqlMapper;
            _studentService = StudentService;
            _logger = logger;
        }

        [HttpPost]
        public string Test([FromBody]int id)
        {
            return id.ToString();
        }

        #region Command

        [HttpPost]
        //[Authorize(ActiveAuthenticationSchemes = "MaiDao.Service")]
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
        //[EnableCors("AllowAll")]
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
            _logger.LogInformation("你访问了首页");
            _logger.LogWarning("警告信息");
            _logger.LogError("错误信息");
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
        [HttpPost]
        public ResponseMessageWrap<GetEntityByIdResponse> GetEntityByRedis()
        {

            var entity = _smartSqlMapper.QuerySingle<Student>(new RequestContext()
            {
                Scope = "T_Student",
                SqlId = "GetListByRedisCache",
                Request = new { }
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