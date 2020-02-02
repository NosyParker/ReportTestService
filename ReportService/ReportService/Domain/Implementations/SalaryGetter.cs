using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ReportService.Domain.Interfaces;


namespace ReportService.Domain.Implementations
{
    /// <summary>
    /// Сервис для получения зарплаты сотрудника
    /// </summary>
    public class SalaryGetter : ISalaryGetter
    {
        private const string salarySystemUrl = "http://salary.local/api/empcode/";

        /// <summary>
        /// Возвращает зарплату сотрудника
        /// </summary>
        /// <param name="inn">ИНН сотрудника</param>
        /// <param name="buhCode">Код сотрудника в системе кадровиков</param>
        /// <returns></returns>
        public async Task<decimal> GetSalary(string inn, string buhCode)
        {
            var json = JsonConvert.SerializeObject(new { buhCode });
            var bodyContent = new StringContent(json, Encoding.Unicode, "application/json");

            using (var http = new HttpClient())
            {
                var response = await http.PostAsync(salarySystemUrl + inn, bodyContent);

                var salaryAsString = await response.Content.ReadAsStringAsync();

                return decimal.Parse(salaryAsString);
            }
        }

    }
}
