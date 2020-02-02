using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ReportService.Domain;
using ReportService.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Tests
{
    /// <summary>
    /// Тесты сервиса, формирующего набор объектов работников с информацией о зарплате
    /// </summary>
    [TestClass]
    public class EmployeeWithFullDataTest
    {

        /// <summary>
        /// Формирует набор данных, который необходимо протестировать
        /// </summary>
        /// <returns></returns>
        private async Task<IEnumerable<Employee>> ConstructTestResults()
        {
            var mockedSalaryGetter = new Mock<ISalaryGetter>();
            mockedSalaryGetter
                .Setup(mock => mock.GetSalary(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(MocksGenerator.GetRandomSalary());

            var mockedEmpCodeGetter = new Mock<IEmpCodeGetter>();
            mockedEmpCodeGetter
                .Setup(mock => mock.GetBuhCode(It.IsAny<string>()))
                .ReturnsAsync(MocksGenerator.GetRandomString());

            var mockedRepo = new Mock<IDatabaseRepository>();
            mockedRepo
                .Setup(mock => mock.GetAllEmployees())
                .ReturnsAsync(MocksGenerator.GetRandomEmployees(fillSalary: false));

            var testedEmployeeFillingService = new EmployeeFillingData(mockedRepo.Object, mockedSalaryGetter.Object, mockedEmpCodeGetter.Object);

            var testedResults = await testedEmployeeFillingService.GetEmployeesWithFilledData();

            return testedResults;
        }

        /// <summary>
        /// Сформированный набор должен быть не nullable
        /// </summary>
        [TestMethod]
        public void EmployeesListIsNotNull()
        {
            var results = ConstructTestResults().Result;

            Assert.IsNotNull(results);

        }


        /// <summary>
        /// Сформированный набор должен содержать элементы
        /// </summary>
        [TestMethod]
        public void EmployeesListIsNotEmpty()
        {
            var results = ConstructTestResults().Result;

            var mustExistElemsInList = results.Any();

            Assert.IsTrue(mustExistElemsInList);
        }


        /// <summary>
        /// Для всех элементов сформированного набора должно быть заполнено поле о зарплате
        /// </summary>
        [TestMethod]
        public void EmployeesListWasFilledSalary()
        {
            var results = ConstructTestResults().Result;

            var mustContainsSalaryData = results.All(emp => emp.Salary > 0.0m);

            Assert.IsTrue(mustContainsSalaryData);

        }

    }
}
