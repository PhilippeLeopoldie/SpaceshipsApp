using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spaceships.Domain.Entities;

namespace Spaceships.Application.Spaceships;

public interface ISpaceshipsService
{
    Task AddAsync(SpaceShip spaceship);
    Task<SpaceShip[]> GetAllAsync();
    Task<SpaceShip?> GetByIdAsync(int id);
}
