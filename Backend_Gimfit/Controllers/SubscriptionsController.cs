using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend_Gimfit.Data;
using Backend_Gimfit.Models;
using Backend_Gimfit.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Gimfit.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubscriptionsController : ControllerBase
    {
        private readonly DataContext _context;

        public SubscriptionsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subscription>>> GetSubscriptions()
        {
            var subscriptions = await _context.Subscriptions.ToListAsync();
            return Ok(subscriptions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Subscription>> GetSubscription(int id)
        {
            var subscription = await _context.Subscriptions.FindAsync(id);

            if (subscription == null)
            {
                return NotFound();
            }

            return Ok(subscription);
        }

        [HttpPost]
        public async Task<ActionResult<Subscription>> PostSubscription(SubscriptionDto subscriptionDto)
        {
            var subscription = new Subscription
            {
                Name = subscriptionDto.Name,
                Price = subscriptionDto.Price,
                Description = subscriptionDto.Description,
                Duration = subscriptionDto.Duration
            };

            _context.Subscriptions.Add(subscription);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSubscription), new { id = subscription.ID }, subscription);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubscription(int id, SubscriptionDto subscriptionDto)
        {
            if (id != subscriptionDto.ID)
            {
                return BadRequest();
            }

            var subscriptionToUpdate = await _context.Subscriptions.FindAsync(id);

            if (subscriptionToUpdate == null)
            {
                return NotFound();
            }

            subscriptionToUpdate.Name = subscriptionDto.Name;
            subscriptionToUpdate.Price = subscriptionDto.Price;
            subscriptionToUpdate.Description = subscriptionDto.Description;
            subscriptionToUpdate.Duration = subscriptionDto.Duration;

            _context.Entry(subscriptionToUpdate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubscriptionExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscription(int id)
        {
            var subscription = await _context.Subscriptions.FindAsync(id);
            if (subscription == null)
            {
                return NotFound();
            }

            _context.Subscriptions.Remove(subscription);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubscriptionExists(int id)
        {
            return _context.Subscriptions.Any(e => e.ID == id);
        }
    }
}
