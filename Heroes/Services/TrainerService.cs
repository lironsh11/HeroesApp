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
    public class TrainerService : ITrainerService
    {

        private readonly HeroesAppDataContext _dbContext;
        public TrainerService(HeroesAppDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Trainer>> GetAllTrainers()
        {
            var result = await _dbContext.Trainers.ToListAsync();
            return result.Select(trainerModel => Map(trainerModel)).ToList();
        }

        public async Task<Trainer> GetById(int id)
        {
            var item = await _dbContext.Trainers.FirstOrDefaultAsync(trainer => trainer.ID == id);
            return Map(item);
        }

        public async Task<Trainer> UpdateTrainer(int id, Trainer currentTrainer)
        {
            var Trainer = await _dbContext.Trainers.FirstOrDefaultAsync(trainer => trainer.ID == id);
            if (Trainer == null)
            {
                throw new InvalidOperationException("cannot update trainer with id " + id);
            }

            Trainer.UserName = currentTrainer.UserName;
            Trainer.Password = currentTrainer.Password;
            await _dbContext.SaveChangesAsync();
            return Map(Trainer);
        }

        public async Task<Trainer> AddNewTrainer(Trainer newTrainer)
        {
            var trainerToAdd = Map(newTrainer);
            _dbContext.Trainers.Add(trainerToAdd);
            await _dbContext.SaveChangesAsync();
            return Map(trainerToAdd);
        }

        public async Task DeleteTrainer(int id)
        {
            var currentTrainer = await _dbContext.Trainers.FirstOrDefaultAsync(trainer => trainer.ID == id);
            if (currentTrainer == null)
            {
                throw new InvalidOperationException("cannot delete trainer with id " + id);
            }
            _dbContext.Trainers.Remove(currentTrainer);
            await _dbContext.SaveChangesAsync();
        }

        private Trainer Map(TrainerModel model)
        {
            return new Trainer
            {
                ID = model.ID,
                UserName = model.UserName,
                Password = model.Password
            };
        }

        private TrainerModel Map(Trainer dto)
        {
            return new TrainerModel
            {
                ID = dto.ID,
                UserName = dto.UserName,
                Password = dto.Password
            };
        }
    }
}
