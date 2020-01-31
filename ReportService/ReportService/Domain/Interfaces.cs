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


    /// <summary>
    /// Базовый интерфейс для реализации паттерна репозитория для доступа к БД
    /// </summary>
    public interface IDatabaseRepository
    {
        /// <summary>
        /// Возвращает сведения о всех сотрудниках в БД
        /// </summary>
        /// <returns></returns>
        IEnumerable<Employee> GetAllEmployees();

        /// <summary>
        /// Возвращает сведения о всех сотрудниках, сгруппированных по отделам
        /// </summary>
        /// <returns></returns>
        IEnumerable<IGrouping<string, Employee>> GetEmployeesByDept();
    }


    /// <summary>
    /// Базовый интерфейс для реализации сервиса получения зарплаты сотрудника
    /// </summary>
    public interface ISalaryGetter
    {
        /// <summary>
        /// Возвращает зарплату сотрудника
        /// </summary>
        /// <returns></returns>
        Task<decimal> GetSalary(Employee employee);
    }


    /// <summary>
    /// Базовый интерфейс для реализации сервиса получения кода сотрудника
    /// </summary>
    public interface IEmpCodeGetter
    {
        /// <summary>
        /// Возвращает код сотрудника
        /// </summary>
        /// <param name="inn">ИНН сотрудника</param>
        /// <returns></returns>
        Task<string> GetBuhCode(string inn);
    }

}
