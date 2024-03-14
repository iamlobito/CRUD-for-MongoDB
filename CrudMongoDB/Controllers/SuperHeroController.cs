using CrudMongoDB.Models;
using CrudMongoDB.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace CrudMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroRepository _superheroRepository;

        public SuperHeroController(ISuperHeroRepository superheroRepository)
        {
            _superheroRepository = superheroRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAll()
        {
            return await _superheroRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetById(string id)
        {
            return await _superheroRepository.GetById(id);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(string id)
        {
            var result = await _superheroRepository.Delete(id);

            if (result)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(SuperHero hero)
        {
            var result = await _superheroRepository.Create(hero);

            if (result)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPut]
        public async Task<ActionResult> Update(SuperHero hero)
        {
            var result = await _superheroRepository.Update(hero);

            if (result)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
