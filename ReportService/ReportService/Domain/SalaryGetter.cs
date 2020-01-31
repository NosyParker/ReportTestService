using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


/// <summary>
/// Сервис для получения зарплаты сотрудника
/// </summary>
public class SalaryGetter : ISalaryGetter
{
    private const string salarySystemUrl = "http://salary.local/api/empcode/";

    /// <summary>
    /// Возвращает зарплату сотрудника
    /// </summary>
    /// <returns></returns>
    public async Task<decimal> GetSalary(Employee employee)
    {
        var json = JsonConvert.SerializeObject(new { employee.BuhCode });
        var bodyContent = new StringContent(json, Encoding.Unicode, "application/json");

        using(var http = new HttpClient())
        {
            var response = await http.PostAsync(salarySystemUrl + employee.Inn, bodyContent);

            var salaryAsString = await response.Content.ReadAsString();

            return decimal.Parse(salaryAsString);
        }
    }

}
