using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ConsulCommmon;

namespace Server1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime lifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            var consulOption = new ConsulCommmon.Model.ConsulOption()
            {
                ServiceName = Configuration["ConsulServerConfig:ServiceName"],
                ServiceIP = Configuration["ConsulServerConfig:ServiceIP"],
                ServicePort = Convert.ToInt32(Configuration["ConsulServerConfig:ServicePort"]),
                ServiceHealthCheck = Configuration["ConsulServerConfig:ServiceHealthCheck"],
                ConsulAddress = Configuration["ConsulServerConfig:ConsulAddress"]
                // 其余三项暂未配置
            };
            app.RegisterConsul(lifetime, consulOption);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
