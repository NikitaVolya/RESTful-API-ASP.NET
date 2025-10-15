using Microsoft.AspNetCore.Mvc;

namespace RESTful_API_ASP.NET.Controllers
{
    [ApiController]
    [Route("api/reports")]
    public class ReportsController : Controller
    {
        [HttpGet("{year}/{month}")]
        public IActionResult GetReport([FromRoute] int year, [FromRoute] int month)
        {
            var report = new
            {
                Year = year,
                Month = month,
                TotalUsers = 123,
                TotalOrders = 456,
                TotalRevenue = 7890.50
            };

            return Ok(report);
        }
    }
}
