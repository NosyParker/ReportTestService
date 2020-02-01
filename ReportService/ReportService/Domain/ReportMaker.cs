using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Domain
{
    /// <summary>
    /// Сервис генерации отчетов по зарплате сотрудников компании
    /// </summary>
    public class ReportMaker : IReportMaker
    {
        private readonly StringBuilder builder;
        private readonly IReportPrettier formatter;
        private readonly IEmployeeFillingData employeeWithDataService;

        public ReportMaker(IEmployeeFillingData employeeFillingService, IReportPrettier reportFormatter)
        {
            builder = new StringBuilder();
            formatter = reportFormatter;
            employeeWithDataService = employeeFillingService;
        }

        /// <summary>
        /// Генерирует итоговый отчет по зарплатам сотрудников
        /// за указанный месяц года в виде байтового массива
        /// </summary>
        /// <returns></returns>
        public async Task<byte[]> GetReport(int year, int month)
        {
            var employees = await employeeWithDataService.GetEmployeesWithFilledData();

            var empByDeps = employees.GroupBy(emp => emp.Department);

            builder.Append(formatter.MakeReportHeader(int year, int month));

            foreach(var group in empByDeps)
            {
                builder.Append(formatter.MakeDeptTitle(group));

                foreach(var emp in group)
                {
                    builder.Append(formatter.MakeEmpSalaryInfo(emp));
                }

                builder.Append(formatter.MakeDeptSalaryInfo(group));
            }

            builder.Append(formatter.MakeTotalSalaryInfo(employees));

            return Encoding.Unicode.GetBytes(builder.ToString());

        }
    }
}
