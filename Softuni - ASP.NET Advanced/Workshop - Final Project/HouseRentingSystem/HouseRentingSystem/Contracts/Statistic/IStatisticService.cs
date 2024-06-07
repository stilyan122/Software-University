using HouseRentingSystem.Services.Statistic;

namespace HouseRentingSystem.Contracts.Statistic
{
    public interface IStatisticService
    {
        Task<StatisticServiceModel> Total();
    }
}
