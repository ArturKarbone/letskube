using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;
using System;

namespace LetsKube
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly ILoggerFactory _loggerFactory;
        public Startup(IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            _configuration = configuration;
            _loggerFactory = loggerFactory;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddRazorPages();
            services.AddHealthChecks()
                .AddCheck("readiness", () =>
                {
                    CreateLogger("HealthCheck:Readiness").LogInformation($"/health/readiness hit. Result: {_configuration.GetValue<string>("HealthCheck:Readiness")}");
                    return new HealthCheckResult(Enum.Parse<HealthStatus>(_configuration.GetValue<string>("HealthCheck:Readiness")));
                })
                .AddCheck("liveness", () =>
                {
                    CreateLogger("HealthCheck:Liveness").LogInformation($"/health/liveness hit. Result: {_configuration.GetValue<string>("HealthCheck:Liveness")}");
                    return new HealthCheckResult(Enum.Parse<HealthStatus>(_configuration.GetValue<string>("HealthCheck:Liveness")));
                })
                .AddCheck("startup", () =>
                {
                    CreateLogger("HealthCheck:Startup").LogInformation($"/health/startup hit. Result: {Environment.GetEnvironmentVariable("HealthCheck:Startup") ?? "Healthy" }");
                    return new HealthCheckResult(Enum.Parse<HealthStatus>(Environment.GetEnvironmentVariable("HealthCheck:Startup") ?? "Healthy"));
                });

            ILogger CreateLogger(string categoryName) => _loggerFactory.CreateLogger(categoryName);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
                endpoints.MapHealthChecks("/health/readiness", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions { Predicate = x => x.Name == "readiness" });
                endpoints.MapHealthChecks("/health/liveness", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions { Predicate = x => x.Name == "liveness" });
                endpoints.MapHealthChecks("/health/startup", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions { Predicate = x => x.Name == "startup" });
            });
        }
    }
}