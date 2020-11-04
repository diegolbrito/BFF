using BFF.APP.HealthChecks;
using BFF.APP.Services.Customers.Clients;
using BFF.APP.Services.Customers.Clients.Interfaces;
using BFF.APP.Services.Customers.Settings;
using BFF.APP.Services.Shopping.Clients;
using BFF.APP.Services.Shopping.Clients.Interfaces;
using BFF.APP.Services.Shopping.Services;
using BFF.APP.Services.Shopping.Services.Interfaces;
using BFF.APP.Services.Shopping.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Linq;
using System.Net.Mime;

namespace BFF.APP
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.Configure<CustomerSettings>(Configuration.GetSection("CustomerSettings"));
            services.Configure<OrderSettings>(Configuration.GetSection("OrderSettings"));
            services.AddHttpClient<ICustomerClient, CustomerClient>();
            services.AddHttpClient<IOrderClient, OrderClient>();
            services.AddTransient<ICustomerOrderService, CustomerOrderService>();
            services.AddHealthChecks().AddCheck<CustomerHealthCheck>("customer");
            services.AddHealthChecks().AddCheck<OrderHealthCheck>("order");
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSerilogRequestLogging();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseHealthChecks("/hc",
               new HealthCheckOptions
               {
                   ResponseWriter = async (context, report) =>
                   {
                       var result = JsonConvert.SerializeObject(
                           new
                           {
                               environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? Environments.Development,
                               status = $"{report.Status}",
                               services = report.Entries.Select(e => new { key = e.Key, value = Enum.GetName(typeof(HealthStatus), e.Value.Status) })
                           });
                       context.Response.ContentType = MediaTypeNames.Application.Json;
                       await context.Response.WriteAsync(result);
                   }
               });
        }
    }
}
