using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Wss.DomianService;
using Wss.DataAccess;
using Swashbuckle.AspNetCore.Swagger;
using NLog.Extensions.Logging;
using NLog.Web;
using Wss.WebService2.Common;
using Microsoft.Extensions.Caching.Distributed;
using Wss.WebService2.Middlewares;

namespace Wss.WebService2
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc((options) =>
            {
                options.Filters.Add(typeof(WebApiExceptionFilterAttribute));
                // options.Filters.Add(typeof(HttpGlobalValidateModelFilter));
            });


            IServiceProvider pro = services.BuildServiceProvider();//ASP.NET Core中的DI容器最终体现为一个IServiceProvider接口，我们将所有实现了该接口的类型及其实例统称为ServiceProvider。
            ServiceDescriptor s;
            /*
             pro.GetService()//IServiceProvider接口里的唯一的方法，实现的DI返回一个类             
             */





            //直接加载出来数据操作类
            services.AddSingleton(SmartSql.MapperContainer.Instance.GetSqlMapper());

            //加载出来Command操作类
            services.AddSingleton<StudentService>();
            services.AddSingleton<StudentDateAccess>(new StudentDateAccess());

            services.AddDistributedMemoryCache();

            #region Swagger的配置            

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Wss API",
                    Description = "Boke ASP.NET Core Web API",
                    TermsOfService = "None",
                    Contact = new Contact { Name = "Light wang", Email = "", Url = "" },
                    License = new License { Name = "Use under LICX", Url = "" }
                });
                c.CustomSchemaIds(type => type.FullName);
            });

            #endregion
            #region 身份认证



            #endregion
            #region 启用session
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.CookieHttpOnly = true;
            });

            #endregion
            #region 跨域脚本访问
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder => builder.AllowAnyOrigin()
                        );
            });

            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            env.EnvironmentName = EnvironmentName.Production;
            var aa = env.IsDevelopment();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //app.UseExceptionHandler("/error");
            }
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();


            app.UseTokenAuthentication(new MaiDao.AspNetCore.Authentication.TokenOptions
            {
                AuthenticationScheme = "MaiDao.Service",
                TokenHeader = "Token",
                TokenQueryString = "Token",
                TokenStore = app.ApplicationServices.GetRequiredService<IDistributedCache>()
            });
            // Create a catch-all response

            app.UseCors("AllowAll");

            app.UseMiddleware<ExceptionMiddlewares>();

            app.UseSession();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", Configuration.GetSection("Swagger")["Title"]);
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute("Student", "{controller}/{action}");
            });

            loggerFactory.AddNLog();//添加NLog  
            env.ConfigureNLog("nlog.config");//读取Nlog配置文件  


            //app.UseStatusCodePages();
            //app.UseExceptionHandler("/Errors/500");
            //app.UseStatusCodePagesWithReExecute("/Errors/{0}");           


        }
    }
}
