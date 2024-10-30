using Microsoft.AspNetCore.Mvc;
using CryptoSphereStats.DataContext;
using System.Linq;

namespace CryptoSphereStats.Controllers
{
        [ApiController]
    [Route("api/[controller]")]
    public class ChartDataController : ControllerBase
    {
        private readonly ChartDataContext _context;

        public ChartDataController(ChartDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetChartData()
        {
            var data = _context.ChartDatas
                .Select(d => new
                {
                    d.Month,
                    d.Value
                })
                .ToList();

            return Ok(data);
        }
    }
}
