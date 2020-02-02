using System.Threading.Tasks;

namespace ReportService.Domain.Interfaces
{
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
}
