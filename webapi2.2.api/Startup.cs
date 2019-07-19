using System;
using System.Diagnostics;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SD.LLBLGen.Pro.DQE.SqlServer;
using SD.LLBLGen.Pro.ORMSupportClasses;
using webapi22.example.data_access;

namespace webapi2._2.api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSession();
            services.AddDistributedMemoryCache();
            services.AddHttpContextAccessor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSession();

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var exception = errorFeature.Error;

                    var problemDetails = new ProblemDetails()
                    {
                        Instance = $"urn:myorganization:error:{Guid.NewGuid()}"
                    };

                    problemDetails.Title = "An unexpected error occurred!";
                    problemDetails.Status = 500;
                    problemDetails.Detail = "Server error occurred.";// exception.Demystify().ToString();

                    context.Response.StatusCode = problemDetails.Status.Value;
                    context.Response.WriteJson(problemDetails, "application/problem+json");
                });
            });

            app.UseHsts();
            app.UseHttpsRedirection();
            app.UseMvc();

            RuntimeConfiguration.AddConnectionString("ConnectionString.SQL Server (SqlClient)", "data source=IP-C613C28D;initial catalog=Webapi22Example;trusted_connection=true;persist security info=False;packet size=4096");

            // Configure the DQE
            RuntimeConfiguration.ConfigureDQE<SQLServerDQEConfiguration>(
                c => c.SetTraceLevel(TraceLevel.Verbose)
                    .AddDbProviderFactory(typeof(System.Data.SqlClient.SqlClientFactory))
                    .SetDefaultCompatibilityLevel(SqlServerCompatibilityLevel.SqlServer2012));

            DataAccess.Init(Convert.ToInt16(Configuration["DataAccessType"]));

        }
    }
}
