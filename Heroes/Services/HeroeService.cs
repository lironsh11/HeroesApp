using Heroes.Interfaces;
using Heroes.Models;
using HeroesApp.DataAccess;
using HeroesApp.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heroes.Services
{
    public class HeroeService : IHeroeService
    {
        private readonly HeroesAppDataContext _dbContext;
        public HeroeService(HeroesAppDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Heroe>> GetAllHeroes()
        {
            var result = await _dbContext.Heroes.ToListAsync();
            return result.Select(heroeModel => Map(heroeModel)).ToList();
        }

        public async Task<Heroe> GetById(int id)
        {
            var item = await _dbContext.Heroes.FirstOrDefaultAsync(heroe => heroe.ID == id);
            return Map(item);
        }
        public async Task<Heroe> UpdateHeroe(int id, Heroe currentHeroe)
        {
            var currentHero = await _dbContext.Heroes.FirstOrDefaultAsync(heroe => heroe.ID == id);
            if (currentHero == null)
            {
                throw new InvalidOperationException("cannot update heroe with id " + id);
            }

            currentHero.Name = currentHeroe.Name;
            currentHero.GuideID = currentHeroe.GuideID;
            currentHero.SuiteColors = currentHeroe.SuiteColors;
            currentHero.CurrentPower = currentHeroe.CurrentPower;
            currentHero.StartingPower = currentHeroe.StartingPower;
            currentHero.Abilty = currentHeroe.Abilty;
            currentHero.StartDate = currentHeroe.StartDate;
            await _dbContext.SaveChangesAsync();
            return Map(currentHero);
        }

        public async Task DeleteHeroe(int id)
        {
            var currentHero = await _dbContext.Heroes.FirstOrDefaultAsync(heroe => heroe.ID == id);
            if (currentHero == null)
            {
                throw new InvalidOperationException("cannot delete heroe with id " + id);
            }
            _dbContext.Heroes.Remove(currentHero);
            await _dbContext.SaveChangesAsync();
        }

        public async  Task<Heroe> AddNewHeroe(Heroe newHeroe)
        {
            var heroeToAdd = Map(newHeroe);
            _dbContext.Heroes.Add(heroeToAdd);
            await _dbContext.SaveChangesAsync();
            return Map(heroeToAdd);
        }

        private Heroe Map(HeroeModel model)
        {
            return new Heroe
            {
                ID = model.ID,
                Name = model.Name,
                GuideID = model.GuideID,
                SuiteColors = model.SuiteColors,
                CurrentPower = model.CurrentPower,
                StartingPower = model.StartingPower,
                Abilty = model.Abilty,
                StartDate = model.StartDate
            };
        }

        private HeroeModel Map(Heroe dto)
        {
            return new HeroeModel
            {
                ID = dto.ID,
                Name = dto.Name,
                GuideID = dto.GuideID,
                SuiteColors = dto.SuiteColors,
                CurrentPower = dto.CurrentPower,
                StartingPower = dto.StartingPower,
                Abilty = dto.Abilty,
                StartDate = dto.StartDate
            };
        }
    }
}
