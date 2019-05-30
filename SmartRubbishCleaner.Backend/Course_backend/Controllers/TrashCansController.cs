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
    public class TrashCansController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TrashCansController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TrashCans
        [HttpGet]
        [ProducesResponseType(typeof(TrashCanModel[]), StatusCodes.Status200OK)]
        public IEnumerable<TrashCanModel> GetTrashCans()
        {
            var trashCanModels = _context.TrashCans.Select(x =>
            new TrashCanModel()
            {
                TrashCanId = x.TrashCanId,
                Latitude = x.Latitude,
                Longtitude = x.Longtitude,
                DeviceId = x.DeviceId
            }).ToList();

            return trashCanModels;
        }

        // GET: api/TrashCans/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TrashCanModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTrashCan([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var trashCan = await _context.TrashCans.FindAsync(id);

            if (trashCan == null)
            {
                return NotFound();
            }

            var trashCanModel = new TrashCanModel()
            {
                TrashCanId = trashCan.TrashCanId,
                Latitude = trashCan.Latitude,
                Longtitude = trashCan.Longtitude,
                DeviceId = trashCan.DeviceId
            };

            return Ok(trashCanModel);
        }

        // PUT: api/TrashCans/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrashCan([FromRoute] int id, [FromBody] TrashCanModel trashCanModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trashCanModel.TrashCanId)
            {
                return BadRequest();
            }

            var trashCan = await _context.TrashCans.FindAsync(trashCanModel.TrashCanId);
            trashCan.Latitude = trashCanModel.Latitude;
            trashCan.Longtitude = trashCanModel.Longtitude;
            trashCan.DeviceId = trashCanModel.DeviceId;

            _context.Entry(trashCan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrashCanExists(id))
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

        // POST: api/TrashCans
        [HttpPost]
        [ProducesResponseType(typeof(object), StatusCodes.Status201Created)]
        public async Task<IActionResult> PostTrashCan([FromBody] TrashCanModel trashCanModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var device = await _context.Devices.Include(x => x.TrashCans).Where(x => x.DeviceId == trashCanModel.DeviceId).FirstOrDefaultAsync();
            var trashCan = new TrashCan()
            {
                Latitude = trashCanModel.Latitude,
                Longtitude = trashCanModel.Longtitude
            };

            if (this.DeviceExists(trashCanModel.DeviceId))
            {
                trashCan.DeviceId = trashCanModel.DeviceId;
                trashCan.Device = await _context.Devices.FindAsync(trashCanModel.DeviceId);
            }
            _context.TrashCans.Add(trashCan);
            await _context.SaveChangesAsync();
            trashCanModel.TrashCanId = trashCan.TrashCanId;

            return CreatedAtAction("GetTrashCan", new { id = trashCanModel.TrashCanId }, trashCanModel);
        }

        // DELETE: api/TrashCans/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(TrashCan), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteTrashCan([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var trashCan = await _context.TrashCans.FindAsync(id);
            if (trashCan == null)
            {
                return NotFound();
            }

            _context.TrashCans.Remove(trashCan);
            await _context.SaveChangesAsync();

            return Ok(trashCan);
        }

        private bool TrashCanExists(int id)
        {
            return _context.TrashCans.Any(e => e.TrashCanId == id);
        }

        private bool DeviceExists(int id)
        {
            return _context.Devices.Any(e => e.DeviceId == id);
        }
    }
}