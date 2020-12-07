using CourseSignUp.Application.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CourseSignUp.Api.Statistics
{
    [ApiController, Route("[controller]")]
    public class StatisticsController : ControllerBase
    {
        private IGetStatisticsCommand _getStatisticsCommand;
        public StatisticsController(IGetStatisticsCommand getStatisticsCommand)
        {
            _getStatisticsCommand = getStatisticsCommand;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = await _getStatisticsCommand.ExecuteAsync();
            return Ok(list);
        }
    }
}