using Heroes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heroes.Interfaces
{
    public interface IHeroeService
    {
        Task<List<Heroe>> GetAllHeroes();

        Task<Heroe> GetById(int id);

        Task<Heroe> UpdateHeroe(int id, Heroe currentHeroe);

        Task DeleteHeroe(int id);

        Task<Heroe> AddNewHeroe(Heroe newHeroe);
    }
}
