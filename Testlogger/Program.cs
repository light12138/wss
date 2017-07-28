using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging.Debug;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Testlogger
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 
            // //注册EncodingProvider实现对中文编码的支持
            // Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            // Func<string, LogLevel, bool> filter = (category, level) => level >= LogLevel.Warning;

            // //ILoggerFactory loggerFactory = new LoggerFactory();
            // //loggerFactory.AddProvider(new ConsoleLoggerProvider(filter, false));
            // //loggerFactory.AddProvider(new DebugLoggerProvider(filter));
            // //ILogger logger = loggerFactory.CreateLogger("App");
            // int eventId = 3721;

            // //ILogger logger = new LoggerFactory()
            // //.AddConsole()
            // //.AddDebug()
            // //.CreateLogger("App");
            // //ILogger logger = new ServiceCollection()
            // //.AddLogging()
            // //.BuildServiceProvider()
            // //.GetService<ILoggerFactory>()
            // //.AddConsole((c, l) => l >= LogLevel.Warning)
            // //.AddDebug((c, l) => l >= LogLevel.Warning)
            // //.CreateLogger("App");


            // //logger.LogInformation(eventId, "升级到最新版本({version})", "1.0.0.rc2");
            // //logger.LogWarning(eventId, "并发量接近上限({maximum}) ", 200);
            // //logger.LogError(eventId, "数据库连接失败(数据库：{Database}，用户名：{User})", "TestDb", "sa");
            // //ILogger logger = new ServiceCollection()
            // // .AddLogging()
            // // .BuildServiceProvider()
            // // .GetService<ILoggerFactory>()
            // // .AddTraceSource(new SourceSwitch("LogWarningOrAbove", "Warning"), new TraceListenerTest())
            // // .CreateLogger("App");


            // //TraceSource traceSource = new TraceSource("App");
            // //traceSource.Listeners.Add(new TraceListenerTest());
            // //traceSource.Switch = new SourceSwitch("LogWarningOrAbove", "Warning");
            // //traceSource.TraceEvent(TraceEventType.Information, eventId, "升级到最新版本({0})", "1.0.0.rc2");
            // //traceSource.TraceEvent(TraceEventType.Warning, eventId, "并发量接近上限({0}) ", 200);
            // //traceSource.TraceEvent(TraceEventType.Error, eventId, "数据库连接失败(数据库：{0}，用户名：{1})", "TestDb", "sa");
            // string aa = "3";
            // aa.ToInt();
            //// string.Compare
            // var list = new List<string>() { "aa", "54546", "afcc" };
            // var a = list.ListOrderby();
            // Console.Read(); 
            #endregion

            var host = new WebHostBuilder()
                .UseKestrel()//指定服务器使用的是web服务主机
                .UseContentRoot(Directory.GetCurrentDirectory())//加载工作目录               
                .UseIISIntegration()//配置服务器的相关设置
                .UseStartup<MyStartup>()//加载配置中间键类
                .UseApplicationInsights()//Configures Microsoft.AspNetCore.Hosting.IWebHostBuilder to use Application Insights
                .ConfigureLogging(factory => factory.AddConsole(LogLevel.Warning).AddDebug())
                .UseSetting("detailedErrors", "true")
                .CaptureStartupErrors(true)//设置启动错误是否应该在web主机的配置设置中捕获。启动时，将捕获启动异常，并返回一个错误页面。如果禁用了，启动异常将被传播。
                .Build();
            host.Run();
        }
    }
}