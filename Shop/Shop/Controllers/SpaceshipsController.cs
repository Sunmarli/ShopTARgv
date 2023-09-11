using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Models.Spaceship;
using System.Xml.Linq;

namespace Shop.Controllers
{
    public class SpaceshipsController : Controller
    { 
        private readonly ShopContext _context;

        public SpaceshipsController(ShopContext context)
        { this._context = context; }

    
        public IActionResult Index()
        
        {
            var result = _context.Spaceships
            .Select(x => new SpaceshipsIndexViewModel()
            {
                Id=x.Id,
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
    }
}
