using HouseRentingSystem.Contracts.Statistic;
using HouseRentingSystem.Services.Statistic;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Controllers.Api
{
    [ApiController]
    [Route("api/statistics")]
    public class StatisticApiController : ControllerBase
    {
        private readonly IStatisticService _statistics;

        public StatisticApiController(IStatisticService statistics)
        {
            _statistics = statistics;
        }

        public async Task<StatisticServiceModel> GetStatistics()
        {
            return await _statistics.Total();
        }
    }
}
