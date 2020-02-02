using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReportService.Domain.Interfaces
{
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
}
