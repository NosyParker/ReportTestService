using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportService.Domain
{
    /// <summary>
    /// Базовый интерфейс классов для заполнения отчетов
    /// </summary>
    public interface IReportFormatter
    {
        /// <summary>
        /// Добавление символа новой строки
        /// </summary>
        Action<Employee, Report> AddNewLine { get;}

        /// <summary>
        /// Добавление строки-разделителя
        /// </summary>
        Action<Employee, Report> AddDividerLine { get; }

        /// <summary>
        /// Добавление таба
        /// </summary>
        Action<Employee, Report> AddTabLine { get; }

        /// <summary>
        /// Добавление ФИО работника
        /// </summary>
        Action<Employee, Report> AddEmployeeName { get; }

        /// <summary>
        /// Добавление зарплаты работника
        /// </summary>
        Action<Employee, Report> AddEmployeeSalary { get; }

        /// <summary>
        /// Добавление отдела работника
        /// </summary>
        Action<Employee, Report> AddEmployeeDepartament { get; }
    }
}
