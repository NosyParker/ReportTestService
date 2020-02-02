using ReportService.Domain.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace ReportService.Domain.Implementations
{
    /// <summary>
    /// Сервис для получения кода сотрудника
    /// </summary>
    public class EmpCodeGetter : IEmpCodeGetter
    {
        private const string buhSystemUrl = "http://buh.local/api/inn/";

        /// <summary>
        /// Возвращает код сотрудника
        /// </summary>
        /// <param name="inn">ИНН сотрудника</param>
        /// <returns></returns>
        public async Task<string> GetBuhCode(string inn)
        {
            using (var http = new HttpClient())
            {
                return await http.GetStringAsync(buhSystemUrl + inn);
            }

        }
    }
}
