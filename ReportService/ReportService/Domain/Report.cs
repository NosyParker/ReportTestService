using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Domain
{
    public class Report
    {

        public StringBuilder ReportBuilder { get; }

        public Report(string startText)
        {
            ReportBuilder = new StringBuilder(startText);
        }

        /// <summary>
        /// Возвращает отчет в виде байтового массива
        /// </summary>
        /// <returns>Итоговый отчет в виде массива байтов</returns>
        public byte[] SaveAsBytes()
        {
            return Encoding.Unicode.GetBytes(ReportBuilder.ToString());
        }
    }
}
