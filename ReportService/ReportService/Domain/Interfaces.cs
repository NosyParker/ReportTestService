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
        /// <param name="inn">ИНН сотрудника</param>
        /// <param name="buhCode">Код сотрудника в системе кадровиков</param>
        /// <returns></returns>
        Task<decimal> GetSalary(string inn, string buhCode);
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


    /// <summary>
    /// Базовый интерфейс для реализации сервиса заполнения
    /// объектов сотрудников необходимыми данными
    /// </summary>
    public interface IEmployeeFillingData
    {
        /// <summary>
        /// Возвращает набор объектов сотрудников, 
        /// заполненных данными о зарплате и кодах сотрудника
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Employee>> GetEmployeesWithFilledData();

    }


    /// <summary>
    /// Базовый интерфейс для реализации сервиса генерации 
    /// отчетов по зарплате сотрудников компании
    /// </summary>
    public interface IReportMaker
    {
        /// <summary>
        /// Генерирует итоговый отчет по зарплатам сотрудников
        /// в виде байтового массива
        /// </summary>
        /// <returns></returns>
        Task<byte[]> GetReport(int year, int month);
    }


    /// <summary>
    /// Базовый интерфейс для реализации сервиса
    /// заполнения/оформления отчетов
    /// </summary>
    public interface IReportPrettier
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
