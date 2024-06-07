using HouseRentingSystem.Contracts.Agent;
using HouseRentingSystem.Infrastructure;
using AgentType = HouseRentingSystem.Infrastructure.Models.Agent;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Services.Agent
{
    public class AgentService : IAgentService
    {
        private readonly ApplicationDbContext _data;

        public AgentService(ApplicationDbContext data)
        {
            _data = data;
        }

        public async Task Create(string userId, string phoneNumber)
        {
            var agent = new AgentType()
            {
                UserId = userId,
                PhoneNumber = phoneNumber
            };

            await _data.Agents.AddAsync(agent);
            await _data.SaveChangesAsync();
        }

        public async Task<bool> ExistsById(string userId)
        {
            return await _data.Agents.AnyAsync(a => a.UserId == userId);
        }

        public async Task<int> GetAgentId(string userId)
        {
            var agent = await _data.Agents.FirstOrDefaultAsync(a => a.UserId == userId);

            return agent?.Id ?? 0;
        }

        public async Task<bool> UserHasRents(string userId)
        {
            return await _data.Houses.AnyAsync(h => h.RenterId == userId);
        }

        public async Task<bool> UserWithPhoneNumberExists(string phoneNumber)
        {
            return await _data.Agents.AnyAsync(a => a.PhoneNumber == phoneNumber);
        }
    }
}
