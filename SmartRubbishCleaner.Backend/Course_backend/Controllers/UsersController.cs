﻿using System;
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
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        [ProducesResponseType(typeof(UserModel[]), StatusCodes.Status200OK)]
        public IEnumerable<UserModel> GetUsers()
        {
            var userModels = _context.SystemUsers.Select(x =>
            new UserModel()
            {
                UserId = x.Id,
                Email = x.Email,
                Name = x.UserName,
                Role = x.Role
            }).ToList();

            return userModels;
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUser([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _context.SystemUsers.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var userModel = new UserModel()
            {
                UserId = user.Id,
                Name = user.UserName,
                Email = user.Email,
                Role = user.Role
            };

            return Ok(userModel);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser([FromRoute] string id, [FromBody] UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userModel.UserId)
            {
                return BadRequest();
            }

            var user = await _context.SystemUsers.FindAsync(userModel.UserId);
            user.UserName = userModel.Name;
            user.Email = userModel.Email;
            user.Role = userModel.Role;

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        [HttpPost]
        [ProducesResponseType(typeof(object), StatusCodes.Status201Created)]
        public async Task<IActionResult> PostUser([FromBody] UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = new User()
            {
                UserName = userModel.Name,
                Email = userModel.Email,
                Role = userModel.Role
            };

            _context.SystemUsers.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = Convert.ToInt32(user.Id) }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteUser([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _context.SystemUsers.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.SystemUsers.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        // GET: api/Users/5/subscription
        [HttpGet("{id}/subscription")]
        [ProducesResponseType(typeof(SubscriptionModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSubscription([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _context.SystemUsers.Include(x=>x.Subscription).Where(x=>x.Id==id).FirstOrDefaultAsync();
            SubscriptionModel subscriptionModel = null;

            if (user.Subscription != null)
            {
                subscriptionModel = new SubscriptionModel()
                {
                    SubscriptionId = user.SubscriptionId ?? 0,
                    IdentificationName = user.Subscription.IdentificationName,
                    Price = user.Subscription.Price
                };
            }

            if (user == null)
            {
                return NotFound();
            }

            return Ok(subscriptionModel);
        }

        // PUT: api/Users/5/subscription
        [HttpPut("{id}/subscription")]
        public async Task<IActionResult> BuySubscription(string id, [FromBody] SubscriptionModel subscriptionModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _context.SystemUsers.FindAsync(id);
            var subscription = await _context.Subscriptions.FindAsync(subscriptionModel.SubscriptionId);

            if (user != null && subscription != null)
            {
                user.SubscriptionId = subscription.SubscriptionId;
                _context.Entry(user).State = EntityState.Modified;
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // DELETE: api/Users/5
        [HttpDelete("{id}/subscription")]
        public async Task<IActionResult> DeleteSubscription([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _context.SystemUsers.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            user.SubscriptionId = null;

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        private bool UserExists(string id)
        {
            return _context.SystemUsers.Any(e => e.Id == id);
        }

        private bool SubscriptionExists(int id)
        {
            return _context.Subscriptions.Any(e => e.SubscriptionId == id);
        }
    }
}