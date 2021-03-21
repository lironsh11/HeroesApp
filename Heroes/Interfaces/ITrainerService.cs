using Heroes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heroes.Interfaces
{
    public interface ITrainerService
    {
        Task<List<Trainer>> GetAllTrainers();

        Task<Trainer> GetById(int id);

        Task<Trainer> UpdateTrainer(int id, Trainer currentTrainer);

        Task DeleteTrainer(int id);

        Task<Trainer> AddNewTrainer(Trainer newTrainer);
    }
}
