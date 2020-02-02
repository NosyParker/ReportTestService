using System.Collections.Generic;
using System.Linq;

namespace ReportService.Domain.Interfaces
{
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
}
