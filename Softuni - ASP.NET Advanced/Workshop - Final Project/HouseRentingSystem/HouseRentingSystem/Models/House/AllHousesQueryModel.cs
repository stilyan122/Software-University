using HouseRentingSystem.Infrastructure.Enums;
using HouseRentingSystem.Services.House;
using System.ComponentModel.DataAnnotations;

namespace HouseRentingSystem.Models.House
{
    public class AllHousesQueryModel
    {
        public const int HousesPerPage = 3;

        public string Category { get; set; } = null!;

        [Display(Name = "Search by text")]
        public string SearchTerm { get; set; } = null!;

        public HouseSorting Sorting { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalHousesCount { get; set; }

        public IEnumerable<string> Categories { get; set; } = null!;

        public IEnumerable<HouseServiceModel> Houses { get; set; }
            = new List<HouseServiceModel>();
    }
}
