using ReportService.Domain;
using System;
using System.Collections.Generic;

namespace ReportService.Tests
{
    /// <summary>
    /// Класс для генерирования фейковых данных
    /// </summary>
    public static class MocksGenerator
    {
        // набор имен сотрудников
        private static string[] employeeNames = {
            "Андрей Сергеевич Бубнов",
            "Григорий Евсеевич Зиновьев",
            "Яков Михайлович Свердлов",
            "Алексей Иванович Рыков",
            "Василий Васильевич Кузнецов",
            "Демьян Сергеевич Коротченко",
            "Михаил Андреевич Суслов",
            "Фрол Романович Козлов",
            "Дмитрий Степанович Полянски",
            "Андрей Павлович Кириленко",
            "Арвид Янович Пельше"
        };

        // набор отделов
        private static string[] departments = {
            "ФинОтдел",
            "Бухгалтерия",
            "ИТ",
            "ОйТи",
            "Отдел контроля рисков",
            "Юристы",
            "Уборщики",
            "Охранники"
        };


        /// <summary>
        /// Формирует набор сотрудников для тестирования
        /// </summary>
        /// <param name="fillSalary">Флаг ,указывающий нужно ли заполнять поле зарплаты</param>
        /// <returns></returns>
        public static IEnumerable<Employee> GetRandomEmployees(bool fillSalary = false)
        {
            var random = new Random();

            var testMocksCount = 100;

            var randomIndexForName = 0;
            var randomIndexForDept = 0;

            var testEmps = new List<Employee>();

            for (var i = 0; i < testMocksCount; i++)
            {
                randomIndexForName = random.Next(0, employeeNames.Length);
                randomIndexForDept = random.Next(0, departments.Length);

                testEmps.Add(new Employee {
                    Name = employeeNames[randomIndexForName],
                    Department = departments[randomIndexForDept],
                    Inn = GetRandomString(),
                    Salary = fillSalary ? GetRandomSalary() : 0.0m
                });
            }

            return testEmps;
        }


        /// <summary>
        /// Возвращает случайное значение зарплаты
        /// </summary>
        /// <returns></returns>
        public static decimal GetRandomSalary()
        {
            var random = new Random();

            return random.Next(12500, 1000000);
        }


        /// <summary>
        /// Возвращает случайную строку
        /// </summary>
        /// <returns></returns>
        public static string GetRandomString()
        {
            return Guid.NewGuid().ToString();
        }

    }
}
