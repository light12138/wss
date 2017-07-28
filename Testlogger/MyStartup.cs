using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Testlogger
{
    public class MyStartup
    {
        public MyStartup(IHostingEnvironment env)
        {
            var builder=new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json",optional:false,reloadOnChange:true)
                 .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

        }

        public IConfigurationRoot Configuration { get; }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            #region 在Startup里面编写中间键
            //app.Use((context, next) =>
            //{
            //    var cultureQuery = context.Request.Query["culture"];
            //    if (!string.IsNullOrWhiteSpace(cultureQuery))
            //    {
            //        var culture = new CultureInfo(cultureQuery);

            //        CultureInfo.CurrentCulture = culture;
            //        CultureInfo.CurrentUICulture = culture;
            //    }

            //    // Call the next delegate/middleware in the pipeline
            //    return next();
            //});

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync(
            //        $"Hello {CultureInfo.CurrentCulture.DisplayName}");
            //}); 
            #endregion

            // 自定义中间键，
            app.UseRequestCulture();
            //app.UseMiddleware<RequestCultureMiddleware>();


            loggerFactory.AddConsole();
            env.EnvironmentName = EnvironmentName.Production;
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }
        }
    }
}
