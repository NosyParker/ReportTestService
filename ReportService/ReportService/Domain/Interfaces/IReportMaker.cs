using System.Threading.Tasks;

namespace ReportService.Domain.Interfaces
{
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
}
