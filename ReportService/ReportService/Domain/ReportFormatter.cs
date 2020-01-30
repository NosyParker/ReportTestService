using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportService.Domain
{
    public class ReportFormatter : IReportFormatter
    {

        /// <summary>
        /// Добавление символа новой строки к отчету
        /// </summary>
        public Action<Employee, Report> AddNewLine { get;} = (employee, report) => report.ReportBuilder.Append(Environment.NewLine);

        /// <summary>
        /// Добавление строки-разделителя к отчету
        /// </summary>
        public Action<Employee, Report> AddDividerLine { get; } = (employee, report) => report.ReportBuilder.Append("--------------------------------------------");

        /// <summary>
        /// Добавление таба к отчету
        /// </summary>
        public Action<Employee, Report> AddTabLine { get; }= (employee, report) => report.ReportBuilder.Append("         ");

        /// <summary>
        /// Добавление ФИО работника к отчету
        /// </summary>
        public Action<Employee, Report> AddEmployeeName { get; } = (employee, report) => report.ReportBuilder.Append(employee.Name);

        /// <summary>
        /// Добавление зарплаты работника к отчету
        /// </summary>
        public Action<Employee, Report> AddEmployeeSalary { get; } = (employee, report) => report.ReportBuilder.Append($"{employee.Salary}р.");

        /// <summary>
        /// Добавление названия отдела работника к отчету
        /// </summary>
        public Action<Employee, Report> AddEmployeeDepartament { get; } = (employee, report) => report.ReportBuilder.Append(employee.Department);


    }
}
