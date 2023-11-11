namespace FastFood.Core.Controllers
{
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using FastFood.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using ViewModels.Positions;

    public class PositionsController : Controller
    {
        private readonly FastFoodContext _context;
        private readonly IMapper _mapper;

        public PositionsController(FastFoodContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePositionInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            var position = _mapper.Map<Position>(model);

            _context.Positions.Add(position);

            await _context.SaveChangesAsync();

            return RedirectToAction("All", "Positions");
        }

        public async Task<IActionResult> All()
        {
            var positions = await _context.Positions
                .ProjectTo<PositionsAllViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return View(positions);
        }
    }
}
