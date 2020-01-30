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
        private readonly IConfiguration config;
        private readonly IReportFormatter formatter;


        public ReportController(IConfiguration configuration, IReportFormatter reportFormatter)
        {
            this.config = configuration;
            this.formatter = reportFormatter;
        }


        [HttpGet]
        [Route("{year}/{month}")]
        public IActionResult Download(int year, int month)
        {
            var actions = new List<(Action<Employee, Report>, Employee)>();

            var report = new Report(MonthNameResolver.MonthName.GetName(year, month));

            var connString = config.GetConnectionString("DatabaseConnection");

            var conn = new NpgsqlConnection(connString);
            conn.Open();
            var cmd = new NpgsqlCommand("SELECT d.name from deps d where d.active = true", conn);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                List<Employee> emplist = new List<Employee>();
                var depName = reader.GetString(0);
                var conn1 = new NpgsqlConnection(connString);
                conn1.Open();
                var cmd1 = new NpgsqlCommand("SELECT e.name, e.inn, d.name from emps e left join deps d on e.departmentid = d.id", conn1);
                var reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {
                    var emp = new Employee() { Name = reader1.GetString(0), Inn = reader1.GetString(1), Department = reader1.GetString(2) };
                    emp.BuhCode = EmpCodeResolver.GetCode(emp.Inn).Result;
                    emp.Salary = emp.Salary();
                    if (emp.Department != depName)
                        continue;
                    emplist.Add(emp);
                }

                actions.Add((formatter.AddNewLine, null));
                actions.Add((formatter.AddDividerLine, null));
                actions.Add((formatter.AddNewLine, null));
                actions.Add((formatter.AddEmployeeDepartament, new Employee() { Department = depName } ));

                var empCount = emplist.Count();
                for (int i = 0; i < empCount; i++)
                {
                    actions.Add((formatter.AddNewLine, null));
                    actions.Add((formatter.AddEmployeeName, emplist[i]));
                    actions.Add((formatter.AddTabLine, null));
                    actions.Add((formatter.AddEmployeeSalary, emplist[i]));
                }

            }
            actions.Add((formatter.AddNewLine, null));
            actions.Add((formatter.AddDividerLine, null));

            foreach (var act in actions)
            {
                act.Item1(act.Item2, report);
            }

            var fileContents = report.SaveAsBytes();
            var response = File(fileContents, "application/octet-stream", "report.txt");
            return response;
        }
    }
}
