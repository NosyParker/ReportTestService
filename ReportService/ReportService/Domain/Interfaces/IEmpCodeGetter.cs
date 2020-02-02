using System.Threading.Tasks;

namespace ReportService.Domain.Interfaces
{
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
