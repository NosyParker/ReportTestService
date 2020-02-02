using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using ReportService.Domain.Interfaces;

namespace ReportService.Domain
{
    /// <summary>
    /// Базовый репозиторий для работы с БД сотрудников
    /// </summary>
    public class EmployeesRepository : IDatabaseRepository
    {
        private readonly string connString;
        private IDbConnection Connection => new NpgsqlConnection(this.connString);

        public EmployeesRepository(IConfiguration configuration)
        {
            this.connString = configuration.GetConnectionString("DatabaseConnection");
        }

        /// <summary>
        /// Возвращает данные всех сотрудников, записи которых есть в БД
        /// </summary>
        /// <returns><see cref="IEnumerable{T}"/>последовательность объектов <see cref="Employee"/></returns>
        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            using (var db = Connection)
            {
                db.Open();

                return await db.QueryAsync<Employee>("SELECT e.name Name, e.inn Inn, d.name Departament " +
                                          "FROM emps e " +
                                          "INNER JOIN deps d ON e.departmentid = d.id");
            }
        }

        /// <summary>
        /// Возвращает данные всех сотрудников, сгруппированных по отделениям
        /// </summary>
        /// <returns><see cref="IEnumerable{T}"/> последовательность сгруппированных объектов
        /// <see cref="Employee"/> по названию отдела <see cref="Employee.Department"/></returns>
        public async Task<IEnumerable<IGrouping<string, Employee>>> GetEmployeesByDept()
        {
            var employees = await this.GetAllEmployees();

            return employees.GroupBy(emp => emp.Department, emp => emp);
        }

    }
}
