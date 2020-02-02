using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportService.Domain
{
    /// <summary>
    /// POCO-модель сотрудника компании
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// ФИО сотрудника
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Название отдела, в котором работает
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// ИНН
        /// </summary>
        public string  Inn { get; set; }

        /// <summary>
        /// Зарплата
        /// </summary>
        public decimal Salary { get; set; }

        /// <summary>
        /// Код в системе кадровиков
        /// </summary>
        public string BuhCode { get; set; }
    }
}
