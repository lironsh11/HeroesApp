using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Heroes.Interfaces;
using Heroes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Heroes.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TrainersController : ControllerBase
    {
        private readonly ITrainerService _trainersService;
        public TrainersController(ITrainerService trainersService)
        {
            _trainersService = trainersService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Trainer>>> GetAll()
        {
            var result = await _trainersService.GetAllTrainers();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Trainer>> GetById(int id)
        {
            var result = await _trainersService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost()]
        public async Task<ActionResult<Trainer>> AddNew(Trainer newTrainer)
        {
            try
            {
                var result = await _trainersService.AddNewTrainer(newTrainer);
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Trainer>> DeleteTrainer(int id)
        {
            try
            {
                await _trainersService.DeleteTrainer(id);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Heroe>> UpdateTrainer(int id, Trainer currentTrainer)
        {
            try
            {
                var trainerWithUpdates = await _trainersService.UpdateTrainer(id, currentTrainer);
                return Ok(trainerWithUpdates);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}