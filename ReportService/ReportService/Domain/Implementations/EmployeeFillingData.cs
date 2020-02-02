using ReportService.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReportService.Domain
{
    /// <summary>
    /// Сервис для получения набора объектов сотрудников,
    /// заполненных необходимыми данными
    /// </summary>
    public class EmployeeFillingData : IEmployeeFillingData
    {
        private readonly IDatabaseRepository repo;
        private readonly ISalaryGetter salaryGetter;
        private readonly IEmpCodeGetter empCodeGetter;

        public EmployeeFillingData(IDatabaseRepository repository,
                                    ISalaryGetter salaryGetterService,
                                    IEmpCodeGetter empCodeGetterService)
        {
            repo = repository;
            salaryGetter = salaryGetterService;
            empCodeGetter = empCodeGetterService;
        }

        /// <summary>
        /// Возвращает набор объектов сотрудников,
        /// заполненных данными о зарплате и кодах сотрудника
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Employee>> GetEmployeesWithFilledData()
        {
            var employees = await repo.GetAllEmployees();

            foreach(var emp in employees)
            {
                emp.BuhCode = await empCodeGetter.GetBuhCode(emp.Inn);
                emp.Salary = await salaryGetter.GetSalary(emp.Inn, emp.BuhCode);
            }

            return employees;
        }

    }

}
