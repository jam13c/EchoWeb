using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace EchoWeb
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                var text = context.Request.Query["text"].Any() ? context.Request.Query["text"][0] : "Hello World!";
                await context.Response.WriteAsync($"{GetIdentifier()} says \"{text}\"");
            });
        }

        public static string GetIdentifier()
        {
            var podId = Environment.GetEnvironmentVariable("PodId");
            return String.IsNullOrEmpty(podId) ? "Application" : $"Pod {podId}";
        }
    }
}
