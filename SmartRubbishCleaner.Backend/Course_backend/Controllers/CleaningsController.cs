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
    public class CleaningsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CleaningsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Cleanings
        [HttpGet]
        [ProducesResponseType(typeof(CleaningModel[]), StatusCodes.Status200OK)]
        public IEnumerable<CleaningModel> GetCleanings()
        {
            var cleaningModels = _context.Cleanings.Select(x =>
            new CleaningModel()
            {
                CleaningId = x.CleaningId,
                Amount = x.Amount,
                RubbishType = x.RubbishType,
                Date = x.Date,
                DeviceId = x.DeviceId,
                Factory = new FactoryModel()
                {
                    FactoryId = x.Factory.FactoryId,
                    Latitude = x.Factory.Latitude,
                    Longtitude = x.Factory.Longtitude
                }
            });

            return cleaningModels;
        }

        // GET: api/Cleanings/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CleaningModel), StatusCodes.Status201Created)]
        public async Task<IActionResult> GetCleaning([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cleaning = await _context.Cleanings.FindAsync(id);

            if (cleaning == null)
            {
                return NotFound();
            }

            var cleaningModel = new CleaningModel()
            {
                CleaningId = cleaning.CleaningId,
                Amount = cleaning.Amount,
                RubbishType = cleaning.RubbishType,
                Date = cleaning.Date,
                DeviceId = cleaning.DeviceId,
                Factory = new FactoryModel()
                {
                    FactoryId = cleaning.Factory.FactoryId,
                    Latitude = cleaning.Factory.Latitude,
                    Longtitude = cleaning.Factory.Longtitude
                }
            };


            return Ok(cleaningModel);
        }

        // PUT: api/Cleanings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCleaning([FromRoute] int id, [FromBody] CleaningModel cleaningModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cleaningModel.CleaningId)
            {
                return BadRequest();
            }

            var cleaning = await _context.Cleanings.FindAsync(cleaningModel.CleaningId);

            cleaning.Amount = cleaningModel.Amount;
            cleaning.RubbishType = cleaningModel.RubbishType;
            cleaning.Date = cleaningModel.Date;
            cleaning.DeviceId = cleaningModel.DeviceId;
            cleaning.FactoryId = cleaningModel.Factory.FactoryId;

            _context.Entry(cleaning).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CleaningExists(id))
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

        // POST: api/Cleanings
        [HttpPost]
        [ProducesResponseType(typeof(object), StatusCodes.Status201Created)]
        public async Task<IActionResult> PostCleaning([FromBody] CleaningModel cleaningModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var cleaning = new Cleaning()
            {
                DeviceId = cleaningModel.DeviceId,
                RubbishType = cleaningModel.RubbishType,
                Amount = cleaningModel.Amount,
                Date = cleaningModel.Date,
                FactoryId = cleaningModel.Factory.FactoryId
            };

            _context.Cleanings.Add(cleaning);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCleaning", new { id = cleaningModel.CleaningId }, cleaning);
        }

        // DELETE: api/Cleanings/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Cleaning), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteCleaning([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cleaning = await _context.Cleanings.FindAsync(id);
            if (cleaning == null)
            {
                return NotFound();
            }

            _context.Cleanings.Remove(cleaning);
            await _context.SaveChangesAsync();

            return Ok(cleaning);
        }

        private bool CleaningExists(int id)
        {
            return _context.Cleanings.Any(e => e.CleaningId == id);
        }
    }
}