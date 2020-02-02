using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportService.Domain
{
    /// <summary>
    /// Класс сервиса заполнения/оформления отчетов
    /// </summary>
    public class ReportPrettier : IReportPrettier
    {
        private const string dividerLine = "--------------------------------------------";
        private const string tabSpace = "\t";

        /// <summary>
        /// Возвращает строку, содержащую информацию по суммарной зарплате сотрудников отдела
        /// </summary>
        /// <param name="deptGroup">Сгруппированный набор объектов сотрудников по отделу</param>
        /// <returns></returns>
        public string MakeDeptSalaryInfo(IGrouping<string, Employee> deptGroup)
        {
            return $"{Environment.NewLine}Всего по отделу: {deptGroup.Sum(emp => emp.Salary).ToString("C")}{Environment.NewLine}";
        }


        /// <summary>
        /// Возвращает строку-подраздел с названием отдела компании
        /// </summary>
        /// <param name="deptGroup">Сгруппированный набор объектов сотрудников по отделу</param>
        /// <returns></returns>
        public string MakeDeptTitle(IGrouping<string, Employee> deptGroup)
        {
            return $"{Environment.NewLine}{dividerLine}{Environment.NewLine}{deptGroup.Key}";
        }


        /// <summary>
        /// Возвращает строку, содержащую информацию о зарплате конкретного сотрудника
        /// </summary>
        /// <param name="employee">Объект сотрудника компании</param>
        /// <returns></returns>
        public string MakeEmpSalaryInfo(Employee employee)
        {
            return $"{Environment.NewLine}{employee.Name}{tabSpace}{employee.Salary.ToString("C")}";
        }


        /// <summary>
        /// Возвращает строку-заголовок отчета по зарплатам сотрудников за указанный период
        /// </summary>
        /// <param name="year">Год</param>
        /// <param name="month">Месяц</param>
        /// <returns></returns>
        public string MakeReportHeader(int year, int month)
        {
            return $"{MonthNameResolver.MonthName.GetName(year, month)} {year}";
        }


        /// <summary>
        /// Возвращает строку, содержащую информацию по зарплате всех сотрудников компании
        /// </summary>
        /// <param name="employees">Последовательность сгруппированных наборов
        /// объектов сотрудников компании</param>
        /// <returns></returns>
        public string MakeTotalSalaryInfo(IEnumerable<IGrouping<string, Employee>> employees)
        {
            return $"{Environment.NewLine}{dividerLine}{Environment.NewLine}Всего по предприятию: {employees.Sum(group => group.Sum(emp => emp.Salary)).ToString("C")}";
        }
    }
}
