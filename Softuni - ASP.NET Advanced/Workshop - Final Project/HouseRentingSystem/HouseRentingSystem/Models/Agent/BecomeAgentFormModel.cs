using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Infrastructure.DataConstants.Agent;

namespace HouseRentingSystem.Models.Agent
{
    public class BecomeAgentFormModel
    {
        [Required]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
        [Display(Name = "Phone Number")]
        [Phone]
        public string PhoneNumber { get; set; } = null!;
    }
}
