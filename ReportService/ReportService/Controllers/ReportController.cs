using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReportService.Domain.Interfaces;

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
            if (year < 2000 || year > 9999 || month < 1 || month > 12) return BadRequest();

            var reportFileName = "report.txt";
            var contentType = "text/plain";

            var fileContents = await reportMaker.GetReport(year, month);

            return File(fileContents, contentType, reportFileName);
        }
    }
}
