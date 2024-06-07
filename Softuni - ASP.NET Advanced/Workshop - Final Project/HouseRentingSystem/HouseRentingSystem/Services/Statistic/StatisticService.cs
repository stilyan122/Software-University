using HouseRentingSystem.Contracts.Statistic;
using HouseRentingSystem.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Services.Statistic
{
    public class StatisticService : IStatisticService
    {
        private readonly ApplicationDbContext _data;

        public StatisticService(ApplicationDbContext data)
        {
            _data = data;
        }

        public async Task<StatisticServiceModel> Total()
        {
            var totalHouses = await _data.Houses.CountAsync();

            var totalRents = await _data.Houses
                .Where(h => h.RenterId != null)
                .CountAsync();

            return new StatisticServiceModel()
            {
                TotalHouses = totalHouses,
                TotalRents = totalRents
            };
        }
    }
}
