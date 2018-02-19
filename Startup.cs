using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace swarm_sample_app
{
    public class Startup
    {
         public IConfiguration Configuration { get; }

         public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                var osName = Environment.MachineName;
                var version = Configuration.GetValue<string>("Version");
                var message = Configuration.GetValue<string>("Message", string.Empty);
                await context.Response.WriteAsync($"{osName}, {version}, {message}");
            });
        }
    }
}
