using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Course_backend.Data;
using Course_backend.Entities;
using Course_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Course_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FactoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Factories
        [HttpGet]
        [ProducesResponseType(typeof(FactoryModel[]), StatusCodes.Status200OK)]
        public IEnumerable<FactoryModel> GetFactories()
        {
            var factoryModels = _context.Factories.Select(x =>
            new FactoryModel()
            {
                FactoryId = x.FactoryId,
                Latitude = x.Latitude,
                Longtitude = x.Longtitude
            }).ToList();

            return factoryModels;
        }

        // GET: api/Factories/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(FactoryModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFactory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var factory = await _context.Factories.FindAsync(id);

            if (factory == null)
            {
                return NotFound();
            }

            var factoryModel = new FactoryModel()
            {
                FactoryId = factory.FactoryId,
                Latitude = factory.Latitude,
                Longtitude = factory.Longtitude
            };

            return Ok(factoryModel);
        }

        // PUT: api/Factories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFactory([FromRoute] int id, [FromBody] FactoryModel factoryModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != factoryModel.FactoryId)
            {
                return BadRequest();
            }

            var factory = await _context.Factories.FindAsync(factoryModel.FactoryId);
            factory.Latitude = factoryModel.Latitude;
            factory.Longtitude = factoryModel.Longtitude;

            _context.Entry(factory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FactoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Factories
        [HttpPost]
        [ProducesResponseType(typeof(object), StatusCodes.Status201Created)]
        public async Task<IActionResult> PostFactory([FromBody] FactoryModel factoryModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var factory = new Factory()
            {
                Latitude = factoryModel.Latitude,
                Longtitude = factoryModel.Longtitude
            };

            _context.Factories.Add(factory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFactory", new { id = factoryModel.FactoryId }, factory);
        }

        // DELETE: api/Factories/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Factory), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteFactory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var factory = await _context.Factories.FindAsync(id);
            if (factory == null)
            {
                return NotFound();
            }

            _context.Factories.Remove(factory);
            await _context.SaveChangesAsync();

            return Ok(factory);
        }

        private bool FactoryExists(int id)
        {
            return _context.Factories.Any(e => e.FactoryId == id);
        }
    }
}