using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend_Gimfit.Data;
using Backend_Gimfit.Models;
using Backend_Gimfit.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend_Gimfit.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrainersController : ControllerBase
    {
        private readonly DataContext _context;

        public TrainersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trainer>>> GetTrainers()
        {
            return await _context.Trainers.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Trainer>> GetTrainer(int id)
        {
            var trainer = await _context.Trainers.FindAsync(id);

            if (trainer == null)
            {
                return NotFound();
            }

            return trainer;
        }

        [HttpPost]
        public async Task<ActionResult<Trainer>> PostTrainer(TrainerDTO trainerDto)
        {
            var trainer = new Trainer
            {
                Email = trainerDto.Email,
                Password = trainerDto.Password,
                PhoneNumber = trainerDto.PhoneNumber,
                Role = trainerDto.Role,
                Name = trainerDto.Name,
                LastName = trainerDto.LastName,
                Age = trainerDto.Age,
                Experience = trainerDto.Experience,
                Photo = trainerDto.Photo,
                Description = trainerDto.Description
            };

            _context.Trainers.Add(trainer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTrainer), new { id = trainer.ID }, trainer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrainer(int id, TrainerDTO trainerDto)
        {
            if (id != trainerDto.ID)
            {
                return BadRequest();
            }

            var trainerToUpdate = await _context.Trainers.FindAsync(id);

            if (trainerToUpdate == null)
            {
                return NotFound();
            }

            trainerToUpdate.Email = trainerDto.Email;
            trainerToUpdate.Password = trainerDto.Password;
            trainerToUpdate.PhoneNumber = trainerDto.PhoneNumber;
            trainerToUpdate.Role = trainerDto.Role;
            trainerToUpdate.Name = trainerDto.Name;
            trainerToUpdate.LastName = trainerDto.LastName;
            trainerToUpdate.Age = trainerDto.Age;
            trainerToUpdate.Experience = trainerDto.Experience;
            trainerToUpdate.Photo = trainerDto.Photo;
            trainerToUpdate.Description = trainerDto.Description;

            _context.Entry(trainerToUpdate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainerExists(id))
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
        public async Task<IActionResult> DeleteTrainer(int id)
        {
            var trainer = await _context.Trainers.FindAsync(id);
            if (trainer == null)
            {
                return NotFound();
            }

            _context.Trainers.Remove(trainer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrainerExists(int id)
        {
            return _context.Trainers.Any(e => e.ID == id);
        }
    }
}
