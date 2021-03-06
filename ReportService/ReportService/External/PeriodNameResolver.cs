﻿using System;
using System.Globalization;

namespace ReportService.External
{
    /// <summary>
    /// Класс для реализации сервиса формирования дат в формате удобночитаемых строк
    /// </summary>
    public static class PeriodNameResolver
    {
        /// <summary>
        /// Формирует строку типа "Месяц Год"
        /// </summary>
        /// <param name="year">Год</param>
        /// <param name="month">Месяц</param>
        /// <returns>Дата в виде удобночитаемой строки</returns>
        public static string GetDate(int year, int month)
        {
            if (month < 1 || month > 12) throw new ArgumentException("Укажите корректный месяц", nameof(month));
            if (year < 1 || year > 9999) throw new ArgumentException("Укажите корректный год", nameof(year));

            return new DateTime(year, month, 1).ToString("MMMM yyyy", CultureInfo.CreateSpecificCulture("ru"));
        }

    }
}
