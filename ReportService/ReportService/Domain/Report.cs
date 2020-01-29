using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportService.Domain
{
    public class Report
    {
        public string S { get; set; }
        public void Save()
        {
            System.IO.File.WriteAllText("D:\\report.txt", S);
        }


        /// <summary>
        /// Возвращает отчет в виде байтового массива
        /// </summary>
        /// <returns>Итоговый отчет в виде массива байтов</returns>
        public byte[] SaveAsBytes()
        {
            return System.Text.Encoding.Unicode.GetBytes(S);
        }
    }
}
