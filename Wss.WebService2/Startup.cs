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
            services.AddMvc();

            //直接加载出来数据操作类
            services.AddSingleton(SmartSql.MapperContainer.Instance.GetSqlMapper());

            //加载出来Command操作类
            services.AddSingleton<StudentService>();
            services.AddSingleton<StudentDateAccess>(new StudentDateAccess());


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
       //     services.AddIdentity<ApplicationUser, IdentityRole>()
       //.AddEntityFrameworkStores<ApplicationDbContext>()
       //.AddDefaultTokenProviders();
          

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute("Student", "{controller}/{action}");
            });
            app.UseExceptionHandler("/Error.html");
        }
    }
}
