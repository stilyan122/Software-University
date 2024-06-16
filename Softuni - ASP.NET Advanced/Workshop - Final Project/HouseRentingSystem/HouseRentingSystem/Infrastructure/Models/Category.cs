using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Infrastructure.DataConstants.Category;

namespace HouseRentingSystem.Infrastructure.Models
{
    public class Category
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public IEnumerable<House> Houses { get; set; } = new List<House>();
    }
}
