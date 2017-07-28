using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Wss.TestTdentity.Services;

namespace Wss.TestIdentity
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
         

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                // 配置身份选项
                // 密码配置
                options.Password.RequireDigit = false;//是否需要数字(0-9).
                options.Password.RequiredLength = 6;//设置密码长度最小为6
                options.Password.RequireNonAlphanumeric = false;//是否包含非字母或数字字符。
                options.Password.RequireUppercase = false;//是否需要大写字母(A-Z).
                options.Password.RequireLowercase = false;//是否需要小写字母(a-z).

                // 锁定设置
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);//账户锁定时长30分钟
                options.Lockout.MaxFailedAccessAttempts = 10;//10次失败的尝试将账户锁定

                // Cookie常用设置
                options.Cookies.ApplicationCookie.ExpireTimeSpan = TimeSpan.FromDays(150);//Cookie 保持有效的时间150天。
                options.Cookies.ApplicationCookie.LoginPath = "/Account/LogIn";//在进行登录时自动重定向。
                options.Cookies.ApplicationCookie.LogoutPath = "/Account/LogOff";//在进行注销时自动重定向。

                //cookie扩展设置（通常不用）
                options.Cookies.ApplicationCookie.CookieName = "YouAppCookieName";//用于保持身份的 Cookie 名称。 默认值为“.AspNet.Cookies”。 
                options.Cookies.ApplicationCookie.AccessDeniedPath = "/Account/AccessDenied";//被拒绝访问或路径无效后的重定向。
                options.Cookies.ApplicationCookie.AutomaticAuthenticate = true;//自动认证
                options.Cookies.ApplicationCookie.AuthenticationScheme = Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme;//选定认证方案的名称。
                options.Cookies.ApplicationCookie.ReturnUrlParameter = Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.ReturnUrlParameter;//登陆或退出后执行动作返回到原来的地址。

                // 用户设置
                options.User.RequireUniqueEmail = true; //是否Email地址必须唯一
            }).AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();


            services.AddMvc();
            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseIdentity();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
