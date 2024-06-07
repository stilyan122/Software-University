using System.ComponentModel.DataAnnotations;

namespace HouseRentingSystem.Services.Agent
{
    public class AgentServiceModel
    {
        [Display(Name = "Full Name")]
        public string FullName { get; set; } = null!;

        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; } = null!;

        public string Email { get; set; } = null!;
    }
}
