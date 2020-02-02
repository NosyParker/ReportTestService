using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReportService.Domain;
using ReportService.Domain.Interfaces;

namespace ReportService
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
            services.AddMvc();
            services.AddSingleton<IConfiguration>(Configuration);

            services.AddSingleton<IDatabaseRepository, EmployeesRepository>();
            services.AddSingleton<IEmpCodeGetter, EmpCodeGetter>();
            services.AddSingleton<ISalaryGetter, SalaryGetter>();
            services.AddSingleton<IEmployeeFillingData, EmployeeFillingData>();
            services.AddSingleton<IReportMaker, ReportMaker>();
            services.AddSingleton<IReportFormatter, ReportFormatter>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
