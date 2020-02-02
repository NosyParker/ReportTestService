using Microsoft.Extensions.DependencyInjection;
using ReportService.Domain.Implementations;
using ReportService.Domain.Interfaces;

namespace ReportService.Extensions
{
    /// <summary>
    /// Класс для реализации extension-метода настройки сервисов приложения
    /// </summary>
    public static class ConfigureServicesExtension
    {
        /// <summary>
        /// Внедрение зависимостей для приложения получения отчетов по зарплате сотрудников
        /// </summary>
        /// <param name="services">Набор сервисов приложения</param>
        public static void InjectReportServiceDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IDatabaseRepository, EmployeesRepository>();
            services.AddSingleton<IEmpCodeGetter, EmpCodeGetter>();
            services.AddSingleton<ISalaryGetter, SalaryGetter>();
            services.AddSingleton<IEmployeeFillingData, EmployeeFillingData>();
            services.AddSingleton<IReportMaker, ReportMaker>();
            services.AddSingleton<IReportFormatter, ReportFormatter>();
        }

    }
}
