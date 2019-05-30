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
    public class DevicesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DevicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Devices
        [HttpGet]
        [ProducesResponseType(typeof(DeviceModel[]), StatusCodes.Status200OK)]
        public IEnumerable<DeviceModel> GetDevices()
        {
            var deviceModels = _context.Devices.Select(x =>
            new DeviceModel()
            {
                DeviceId = x.DeviceId,
                ActionRange = x.ActionRange,
                MaxVolume = x.MaxVolume,
                MaxWeight = x.MaxWeight,
                Owner = new UserModel()
                {
                    UserId = x.Owner.Id,
                    Email = x.Owner.Email,
                    Name = x.Owner.UserName,
                    Role = x.Owner.Role
                }
            }).ToList();

            return deviceModels;
        }

        // GET: api/Devices/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(DeviceModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDevice([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var device = await _context.Devices.Include(x => x.Owner).Where(x => x.DeviceId == id).FirstOrDefaultAsync();

            if (device == null)
            {
                return NotFound();
            }

            var deviceModel = new DeviceModel()
            {
                DeviceId = device.DeviceId,
                ActionRange = device.ActionRange,
                MaxVolume = device.MaxVolume,
                MaxWeight = device.MaxWeight,
                Owner = new UserModel()
                {
                    UserId = device.Owner.Id,
                    Email = device.Owner.Email,
                    Name = device.Owner.UserName,
                    Role = device.Owner.Role
                }
            };

            return Ok(deviceModel);
        }

        // PUT: api/Devices/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDevice([FromRoute] int id, [FromBody] DeviceModel deviceModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != deviceModel.DeviceId)
            {
                return BadRequest();
            }
            var device = await _context.Devices.FindAsync(deviceModel.DeviceId);
            device.MaxVolume = deviceModel.MaxVolume;
            device.ActionRange = deviceModel.ActionRange;
            device.MaxWeight = deviceModel.MaxWeight;
            if (deviceModel.Owner != null && this.UserExists(deviceModel.Owner.UserId))
            {
                device.UserId = deviceModel.Owner.UserId;
                device.Owner = await _context.SystemUsers.FindAsync(deviceModel.Owner.UserId);
            }
            else
            {
                device.Owner = await _context.SystemUsers.Where(x => x.Role == "admin").FirstOrDefaultAsync();
                device.UserId = device.Owner.Id;
            }

            _context.Entry(device).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeviceExists(id))
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

        // POST: api/Devices
        [HttpPost]
        [ProducesResponseType(typeof(object), StatusCodes.Status201Created)]
        public async Task<IActionResult> PostDevice([FromBody] DeviceModel deviceModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var device = new Device()
            {
                ActionRange = deviceModel.ActionRange,
                MaxVolume = deviceModel.MaxVolume,
                MaxWeight = deviceModel.MaxWeight
            };

            if (deviceModel.Owner != null && this.UserExists(deviceModel.Owner.UserId))
            {
                device.UserId = deviceModel.Owner.UserId;
                device.Owner = await _context.SystemUsers.FindAsync(deviceModel.Owner.UserId);
            }

            _context.Devices.Add(device);
            await _context.SaveChangesAsync();
            deviceModel.DeviceId = device.DeviceId;
            return CreatedAtAction("GetDevice", new { id = device.DeviceId }, deviceModel);
        }

        // DELETE: api/Devices/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Device), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteDevice([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var device = await _context.Devices.FindAsync(id);
            if (device == null)
            {
                return NotFound();
            }

            _context.Devices.Remove(device);
            await _context.SaveChangesAsync();

            return Ok(device);
        }



        private bool DeviceExists(int id)
        {
            return _context.Devices.Any(e => e.DeviceId == id);
        }

        private bool UserExists(string id)
        {
            return _context.SystemUsers.Any(e => e.Id == id);
        }

        [HttpGet("{type}")]
        [ProducesResponseType(typeof(double), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDeviceEfficiency([FromRoute] int type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var device = await _context.Devices.Include(x => x.Owner).Where(x => x.DeviceId == type).FirstOrDefaultAsync();

            if (device == null)
            {
                return NotFound();
            }
            var cleanings = _context.Cleanings.Include(x => x.Device).Where(x => x.Date.Month == DateTime.Now.Month);
            var dict = new Dictionary<Device, int>();
            foreach (var el in _context.Devices)
            {
                dict.Add(el, cleanings.Where(x => x.DeviceId == el.DeviceId).Select(x => x.Amount).Sum());
            }
            var max = dict.Values.Max();
            var current = dict[device];
            return Ok((double)current / max);
        }

        [HttpGet("unoptimized/{deviceId}")]
        [ProducesResponseType(typeof(TrashCanModel[]), StatusCodes.Status200OK)]
        public async Task<IEnumerable<TrashCanModel>> PostTrashCansWithinRange([FromRoute]int deviceId)
        {
            var model = GetCurrentCoordinates(deviceId, "");
            var cans = await _context.TrashCans.Include(x => x.Device).ToListAsync();
            var device = await _context.Devices.Where(x => x.DeviceId == deviceId).FirstOrDefaultAsync();
            var result = new List<TrashCan>();
            foreach (var can in cans.Where(x=>x.DeviceId==device.DeviceId).ToList())
            {
                if (GetDistance(can.Longtitude, can.Latitude, model.X, model.Y) <= 1.0)
                {
                    result.Add(can);
                }
            }
            return result.Select(x => new TrashCanModel()
            {
                DeviceId = x.DeviceId,
                Latitude = x.Latitude,
                Longtitude = x.Longtitude,
                TrashCanId = x.TrashCanId
            }).ToList();
        }

        [HttpGet("optimized/{deviceId}")]
        [ProducesResponseType(typeof(TrashCanModel[]), StatusCodes.Status200OK)]
        public IEnumerable<TrashCanModel> GetOptimizedTrashCans([FromRoute] int deviceId)
        {
            var model = GetCurrentCoordinates(deviceId, "");
            var cans = _context.TrashCans.Include(x => x.Device).Where(x=>x.DeviceId==deviceId).ToList();
            var device = _context.Devices.Where(x => x.DeviceId == deviceId).FirstOrDefault();
            var result = new List<TrashCan>();
            foreach (var can in cans)
            {
                if (GetDistance(can.Longtitude, can.Latitude, model.X, model.Y) <= device.ActionRange)
                {
                    result.Add(can);
                }
            }
            var graph = new List<List<double>>();
            for (int i = 0; i < result.Count; i++)
            {
                graph.Add(new List<double>());
                for (int j = 0; j < result.Count; j++)
                {
                    if (i == j)
                    {
                        graph[i].Add(double.PositiveInfinity);
                    }
                    else
                    {
                        graph[i].Add(GetDistance(result[i].Longtitude, result[i].Latitude, result[j].Longtitude, result[j].Latitude));
                    }
                }
            }
            var route = Graph.Calculate(graph);
            var final = new List<TrashCan>();
            foreach (var symb in route)
            {
                final.Add(result[(int)char.GetNumericValue(symb)]);
            }
            return final.Select(x=>new TrashCanModel()
            {
                DeviceId = x.DeviceId,
                Longtitude = x.Longtitude,
                Latitude = x.Latitude,
                TrashCanId = x.TrashCanId
            }).ToList();
        }

        private double GetDistance(double long1, double latt1, double long2, double latt2)
        {
            var theta = Math.Abs(long1 - long2);
            latt1 = GetRads(latt1);
            latt2 = GetRads(latt2);
            theta = GetRads(theta);
            var centralangle = Math.Acos(Math.Sin(latt1)*Math.Sin(latt2) + Math.Cos(latt1)*Math.Cos(latt2)*Math.Cos(theta));
            return 40000.0 * centralangle / (2 * Math.PI);
        }

        private double GetRads(double angle)
        {
            return angle * Math.PI / 180.0;
        }

        [HttpPost("{DeviceId, rubbish}")]
        [ProducesResponseType(typeof(PointModel), StatusCodes.Status200OK)]
        public PointModel GetCurrentCoordinates([FromBody] int DeviceId, string rubbish)
        {
            return new PointModel()
            {
                
                X = 36.228528,
                Y = 50.014850
            };
        }

        [HttpGet("time/{deviceId}")]
        [ProducesResponseType(typeof(double), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetNeededSpeed([FromRoute] int deviceId)
        {
            var device = await _context.Devices.Include(x => x.Cleanings).Where(x => x.DeviceId == deviceId).FirstOrDefaultAsync();
            var cleanings = device.Cleanings.Where(x => (x.Date - DateTime.Now.AddDays(-7) > new TimeSpan())).ToList();
            var groupedCleanings = new List<List<Cleaning>>();
            for (int i=0; i<cleanings.Count-2; i += 3)
            {
                groupedCleanings.Add(cleanings.GetRange(i, 3));
            }
            return Ok(TimeOptimization.GetNeededTime(groupedCleanings));
        }

    }
}