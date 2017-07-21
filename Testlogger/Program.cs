using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging.Debug;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Testlogger
{
    class Program
    {
        static void Main(string[] args)
        {
            //注册EncodingProvider实现对中文编码的支持
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            Func<string, LogLevel, bool> filter = (category, level) => level >= LogLevel.Warning;

            //ILoggerFactory loggerFactory = new LoggerFactory();
            //loggerFactory.AddProvider(new ConsoleLoggerProvider(filter, false));
            //loggerFactory.AddProvider(new DebugLoggerProvider(filter));
            //ILogger logger = loggerFactory.CreateLogger("App");
            int eventId = 3721;

            //ILogger logger = new LoggerFactory()
            //.AddConsole()
            //.AddDebug()
            //.CreateLogger("App");
            //ILogger logger = new ServiceCollection()
            //.AddLogging()
            //.BuildServiceProvider()
            //.GetService<ILoggerFactory>()
            //.AddConsole((c, l) => l >= LogLevel.Warning)
            //.AddDebug((c, l) => l >= LogLevel.Warning)
            //.CreateLogger("App");


            //logger.LogInformation(eventId, "升级到最新版本({version})", "1.0.0.rc2");
            //logger.LogWarning(eventId, "并发量接近上限({maximum}) ", 200);
            //logger.LogError(eventId, "数据库连接失败(数据库：{Database}，用户名：{User})", "TestDb", "sa");
            //ILogger logger = new ServiceCollection()
            // .AddLogging()
            // .BuildServiceProvider()
            // .GetService<ILoggerFactory>()
            // .AddTraceSource(new SourceSwitch("LogWarningOrAbove", "Warning"), new TraceListenerTest())
            // .CreateLogger("App");


            //TraceSource traceSource = new TraceSource("App");
            //traceSource.Listeners.Add(new TraceListenerTest());
            //traceSource.Switch = new SourceSwitch("LogWarningOrAbove", "Warning");
            //traceSource.TraceEvent(TraceEventType.Information, eventId, "升级到最新版本({0})", "1.0.0.rc2");
            //traceSource.TraceEvent(TraceEventType.Warning, eventId, "并发量接近上限({0}) ", 200);
            //traceSource.TraceEvent(TraceEventType.Error, eventId, "数据库连接失败(数据库：{0}，用户名：{1})", "TestDb", "sa");
            string aa = "3";
            aa.ToInt();
           // string.Compare
            var list = new List<string>() { "aa", "54546", "afcc" };
            var a = list.ListOrderby();
            Console.Read();
        }
    }
}