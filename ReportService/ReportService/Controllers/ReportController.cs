using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Npgsql;
using ReportService.Domain;

namespace ReportService.Controllers
{
    [Route("api/[controller]")]
    public class ReportController : Controller
    {
        private readonly IReportMaker reportMaker;

        public ReportController(IReportMaker reportMakerService)
        {
            reportMaker = reportMakerService;
        }


        [HttpGet]
        [Route("{year}/{month}")]
        public async Task<IActionResult> Download(int year, int month)
        {
            if (year < 2000 || month < 1 || month > 12) return BadRequest();

            var reportFileName = "report.txt";
            var contentType = "text/plain";

            var fileContents = await reportMaker.GetReport(year, month);

            return File(fileContents, contentType, reportFileName);
        }
    }
}
