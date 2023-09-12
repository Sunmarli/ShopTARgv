using Shop.Core.Domain;
using Shop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAplicationServices.Services
{
    public class SpaceshipServices
    {
        private readonly ShopContext _context;

        public SpaceshipServices
            (
             ShopContext context
            ) 
        { _context = context; }

        public async Task<Spaceship>Create(Spaceship dto)
        {
            Spaceship spaceship = new Spaceship();
            spaceship.Id = Guid.NewGuid();
            spaceship.Name = dto.Name;
            spaceship.Type = dto.Type;
            spaceship.Passengers = dto.Passengers;
            spaceship.EnginePower = dto.EnginePower;
            spaceship.Crew = dto.Crew;
            spaceship.Company = dto.Company;
            spaceship.CargoWeight = dto.CargoWeight;
            spaceship.CreatedAt = DateTime.Now;
            spaceship.Modified = DateTime.Now;


            await _context.Spaceships.AddAsync( spaceship );
            await _context.SaveChangesAsync();  
            return spaceship;
        }


    }
}
