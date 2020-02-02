using System.Collections.Generic;
using System.Linq;

namespace ReportService.Domain.Interfaces
{
    /// <summary>
    /// Базовый интерфейс для реализации сервиса
    /// заполнения/оформления отчетов
    /// </summary>
    public interface IReportFormatter
    {
        /// <summary>
        /// Генерирует заголовок отчета
        /// </summary>
        /// <returns></returns>
        string MakeReportHeader(int year, int month);

        /// <summary>
        /// Генерирует подраздел с названием отдела
        /// </summary>
        /// <returns></returns>
        string MakeDeptTitle(IGrouping<string, Employee> deptGroup);

        /// <summary>
        /// Генерирует строку с информацией о зарплате конкретного сотрудника
        /// </summary>
        /// <returns></returns>
        string MakeEmpSalaryInfo(Employee employee);

        /// <summary>
        /// Генерирует раздел с информацией о зарплате всего отдела
        /// </summary>
        /// <returns></returns>
        string MakeDeptSalaryInfo(IGrouping<string, Employee> deptGroup);

        /// <summary>
        /// Генерирует раздел с информацией о зарплате всей компании
        /// </summary>
        /// <returns></returns>
        string MakeTotalSalaryInfo(IEnumerable<IGrouping<string, Employee>> employees);
    }
}
