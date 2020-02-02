using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ReportService.Controllers;
using ReportService.Domain;
using ReportService.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportService.Tests
{
    /// <summary>
    /// Тесты контроллера, возвращающего итоговый отчет
    /// </summary>
    [TestClass]
    public class ReportControllerTest
    {
        /// <summary>
        /// Формирование объекта контроллера для тестов
        /// </summary>
        /// <returns></returns>
        private ReportController ConstructController()
        {
            var mockedEmployeeWithFilledData = new Mock<IEmployeeFillingData>();
            mockedEmployeeWithFilledData
                .Setup(mock => mock.GetEmployeesWithFilledData())
                .ReturnsAsync(MocksGenerator.GetRandomEmployees(fillSalary: true));

            var mockedReportFormatter = new Mock<ReportFormatter>();
            var mockReportMaker = new Mock<ReportMaker>(mockedEmployeeWithFilledData.Object, mockedReportFormatter.Object);

            var controller = new ReportController(mockReportMaker.Object);

            return controller;
        }


        /// <summary>
        /// Результат работы контроллера при валидных входных данных - файл
        /// </summary>
        [TestMethod]
        public void ReturnedResultIsFileWhenInputParamsAreOk()
        {
            var month = DateTime.Now.Month;
            var year = DateTime.Now.Year;

            var controller = ConstructController();

            var result = controller.Download(year, month).Result;

            Assert.IsInstanceOfType(result, typeof(FileContentResult));
        }


        /// <summary>
        /// Результат работы контроллера при валидных входных данных - не nullable объект
        /// </summary>
        [TestMethod]
        public void ReturnedResultIsNotNullWhenInputParamsAreOk()
        {
            var month = DateTime.Now.Month;
            var year = DateTime.Now.Year;

            var controller = ConstructController();

            var result = controller.Download(year, month).Result;

            Assert.IsNotNull(result);
        }


        /// <summary>
        /// Файл не должен быть пустым при валидных входных данных
        /// </summary>
        [TestMethod]
        public void ReturnedFileContentsIsNotEmptyWhenInputParamsAreOk()
        {
            var month = DateTime.Now.Month;
            var year = DateTime.Now.Year;

            var controller = ConstructController();

            var result = controller.Download(year, month).Result;

            Assert.IsTrue(((FileContentResult)result).FileContents.Length > 0);
        }

        
        /// <summary>
        /// Если ввели некорректное значение месяца -> 400 ошибка
        /// </summary>
        [TestMethod]
        public void ReturnsBadRequestWhenInputMonthIsIncorrect()
        {
            var month = -90;
            var year = DateTime.Now.Year;

            var controller = ConstructController();

            var result = controller.Download(year, month).Result;

            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }


        /// <summary>
        /// Если ввели некорректное значение года -> 400 ошибка
        /// </summary>
        [TestMethod]
        public void ReturnsBadRequestWhenInputYearIsIncorrect()
        {
            var month = DateTime.Now.Month;
            var year = 1900;

            var controller = ConstructController();

            var result = controller.Download(year, month).Result;

            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

    }
}
