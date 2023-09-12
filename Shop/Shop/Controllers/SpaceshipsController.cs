using Microsoft.AspNetCore.Mvc;
using Shop.Core.Dto;
using Shop.Core.ServiceInterface;
using Shop.Data;
using Shop.Models.Spaceship;
using System.Xml.Linq;

namespace Shop.Controllers
{
    public class SpaceshipsController : Controller
    {
        private readonly ShopContext _context;
        private readonly ISpaceshipServices _spaceshipServices;

        public SpaceshipsController
            (ShopContext context,
            ISpaceshipServices spaceshipServices)
        { this._context = context;
            _spaceshipServices = spaceshipServices;
        }


        public IActionResult Index()

        {
            var result = _context.Spaceships
            .Select(x => new SpaceshipsIndexViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Type = x.Type,
                EnginePower = x.EnginePower,
                Passengers = x.Passengers

            });

            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(SpaceshipsCreateViewModel vm)
        {
            var dto = new SpaceshipDto()
            {
                Id = vm.Id,
                Name = vm.Name,
                Type = vm.Type,
                Passengers = vm.Passengers,
                EnginePower = vm.EnginePower,
                Company = vm.Company,
                Crew = vm.Crew,
                CargoWeight = vm.CargoWeight,

            };

            var result = await _spaceshipServices.Create(dto);



            return RedirectToAction(nameof(Index),vm) ;
        }
    }
}
