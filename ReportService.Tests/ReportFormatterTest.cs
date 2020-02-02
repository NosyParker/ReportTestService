using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReportService.Domain.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportService.Tests
{
    /// <summary>
    /// Класс для тестирования сервиса заполнения/форматирования отчетов
    /// </summary>
    [TestClass]
    public class ReportFormatterTest
    {
        private const string dividerLine = "--------------------------------------------";

        /// <summary>
        /// Заполнение шапки отчета корректно и соответствует логике формирования сервисом
        /// </summary>
        [TestMethod]
        public void ReportHeaderIsCorrect()
        {
            var reportFormatter = new ReportFormatter();

            var expectedReportHeader = "Январь 2020";

            var factReportHeader = reportFormatter.MakeReportHeader(2020, 1);

            Assert.AreEqual(expectedReportHeader, factReportHeader);
        }


        /// <summary>
        /// Заполнение строки о суммарной зарплате по отделу корректно и соответствует логике формирования сервисом
        /// </summary>
        [TestMethod]
        public void DeptSalaryInfoIsCorrect()
        {
            var reportFormatter = new ReportFormatter();

            var deptInfo = MocksGenerator.GetRandomEmployees(fillSalary: true).GroupBy(x => x.Department).First();

            var expectedDeptSalaryInfo = $"{Environment.NewLine}Всего по отделу: {deptInfo.Sum(x => x.Salary).ToString("C")}{Environment.NewLine}";

            var factDeptSalaryInfo = reportFormatter.MakeDeptSalaryInfo(deptInfo);

            Assert.AreEqual(expectedDeptSalaryInfo, factDeptSalaryInfo);

        }


        /// <summary>
        /// Заполнение строки с названием отдела корректно и соответствует логике формирования сервисом
        /// </summary>
        [TestMethod]
        public void DeptTitleIsCorrect()
        {
            var reportFormatter = new ReportFormatter();

            var deptInfo = MocksGenerator.GetRandomEmployees(fillSalary: true).GroupBy(x => x.Department).First();

            var expectedDeptTitle = $"{Environment.NewLine}{dividerLine}{Environment.NewLine}{deptInfo.Key}";

            var factDeptTitle = reportFormatter.MakeDeptTitle(deptInfo);

            Assert.AreEqual(expectedDeptTitle, factDeptTitle);
        }


        /// <summary>
        /// Заполнение строки с информацией о зарплате конкретного сотрудника корректно
        /// и соответствует логике формирования сервисом
        /// </summary>
        [TestMethod]
        public void EmpSalaryInfoIsCorrect()
        {
            var reportFormatter = new ReportFormatter();
            var emp = MocksGenerator.GetRandomEmployees(fillSalary: true).GroupBy(x => x.Department).First().First();

            var expectedSalaryInfo = $"{Environment.NewLine}{emp.Name}\t{emp.Salary.ToString("C")}";

            var factSalaryInfo = reportFormatter.MakeEmpSalaryInfo(emp);

            Assert.AreEqual(expectedSalaryInfo, factSalaryInfo);
        }


        /// <summary>
        /// Заполнение строки с суммарной информацией о зарплате всего предприятия корректно
        /// и соответствует логике формирования сервисом
        /// </summary>
        [TestMethod]
        public void TotalSalaryInfoIsCorrect()
        {
            var reportFormatter = new ReportFormatter();
            var empsByDepts = MocksGenerator.GetRandomEmployees(fillSalary: true).GroupBy(x => x.Department);

            var expectedTotalSalaryInfo = $"{Environment.NewLine}{dividerLine}{Environment.NewLine}Всего по предприятию: {empsByDepts.Sum(dept => dept.Sum(emp => emp.Salary)).ToString("C")}";

            var factTotalSalaryInfo = reportFormatter.MakeTotalSalaryInfo(empsByDepts);

            Assert.AreEqual(expectedTotalSalaryInfo, factTotalSalaryInfo);
        }

    }
}
