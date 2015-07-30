using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;
using MyLibrary;
using Microsoft.Framework.ConfigurationModel;

namespace DemoNetConf
{
    public class Startup
    {
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<IMySiteCultureService, MySiteCultureService>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.Use(async (ctx, next) =>
            {
                Console.WriteLine("Hello pipeline, {0}", ctx.Request.Path);
                await next();
            });

            var configuration = new Configuration();
            configuration.AddEnvironmentVariables().AddJsonFile("Config.Json");
            var title = configuration.Get("AppSettings:Title");

            app.UseMvc();
            app.Run(async (context) =>
            {
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync("Hello Conf!");
            });
        }
    }
}
