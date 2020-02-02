using System;
using System.Globalization;

namespace ReportService.External
{
    /// <summary>
    /// Класс для реализации сервиса формирования дат в формате удобночитаемых строк
    /// </summary>
    public static class PeriodResolver
    {
        /// <summary>
        /// Формирует строку типа "Месяц Год"
        /// </summary>
        /// <param name="year">Год</param>
        /// <param name="month">Месяц</param>
        /// <returns>Дата в виде удобночитаемой строки</returns>
        public static string GetDate(int year, int month)
        {
            return new DateTime(year, month, 1).ToString("MMMM yyyy", CultureInfo.CreateSpecificCulture("ru"));
        }

    }
}
