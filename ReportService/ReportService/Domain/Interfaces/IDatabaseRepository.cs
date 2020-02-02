using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        Task<IEnumerable<Employee>> GetAllEmployees();

        /// <summary>
        /// Возвращает сведения о всех сотрудниках, сгруппированных по отделам
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<IGrouping<string, Employee>>> GetEmployeesByDept();
    }
}
