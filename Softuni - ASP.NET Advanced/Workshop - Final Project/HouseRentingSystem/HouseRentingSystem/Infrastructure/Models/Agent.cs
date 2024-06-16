using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Infrastructure.DataConstants.Agent;

namespace HouseRentingSystem.Infrastructure.Models
{
    public class Agent
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        public string UserId { get; set; } = null!;

        public ApplicationUser User { get; set; } = null!;
    }
}
