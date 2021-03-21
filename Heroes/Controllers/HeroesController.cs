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
    public class HeroesController : ControllerBase
    {
        private readonly IHeroeService _heroesService;
        public HeroesController(IHeroeService heroesService)
        {
            _heroesService = heroesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Heroe>>> GetAll()
        {
            var result = await _heroesService.GetAllHeroes();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Heroe>> GetById(int id)
        {
            var result = await _heroesService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost()]
        public async Task<ActionResult<Heroe>> AddNew(Heroe newHeroe)
        {
            try
            {
                var result = await _heroesService.AddNewHeroe(newHeroe);
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Heroe>> DeleteHeroe(int id)
        {
            try
            {
                await _heroesService.DeleteHeroe(id);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Heroe>> UpdateHeroe(int id, Heroe currentHeroe)
        {
            try
            {
                var heroeWithUpdates = await _heroesService.UpdateHeroe(id, currentHeroe);
                return Ok(heroeWithUpdates);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}