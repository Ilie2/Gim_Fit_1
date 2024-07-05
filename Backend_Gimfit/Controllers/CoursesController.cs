/*using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend_Gimfit.Data;
using Backend_Gimfit.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend_Gimfit.DTO;

namespace Backend_Gimfit.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly DataContext _context;

        public CoursesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            return await _context.Courses
                .Include(c => c.Subscription)
                .Include(c => c.Trainer)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            var course = await _context.Courses
                .Include(c => c.Subscription)
                .Include(c => c.Trainer)
                .FirstOrDefaultAsync(c => c.ID == id);

            if (course == null)
            {
                return NotFound();
            }

            return course;
        }

        [HttpPost]
        public async Task<ActionResult<Course>> PostCourse(CourseDTO courseDTO)
        {
            try
            {
                // Verificăm dacă trainerul există înainte de a crea cursul
                var existingTrainer = await _context.Trainers.FindAsync(courseDTO.Trainer.Id);
                if (existingTrainer == null)
                {
                    return BadRequest("Trainerul specificat nu există.");
                }

                // Mapează DTO-ul într-un obiect de tip Course
                var course = new Course
                {
                    Name = courseDTO.Name,
                    Description = courseDTO.Description,
                    Duration = courseDTO.Duration,
                    Capacity = courseDTO.Capacity,
                    SubscriptionId = courseDTO.SubscriptionId,
                    TrainerId = courseDTO.Trainer.Id // Setăm ID-ul trainerului asociat
                };

                // Adăugăm cursul și salvăm modificările în baza de date
                _context.Courses.Add(course);
                await _context.SaveChangesAsync();

                // Returnăm răspunsul de tip CreatedAtAction
                return CreatedAtAction(nameof(GetCourse), new { id = course.Id }, course);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Eroare internă: {ex.Message}");
            }
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(int id, CourseDTO courseDTO)
        {
            if (id != courseDTO.ID)
            {
                return BadRequest();
            }

            var subscription = await _context.Subscriptions.FindAsync(courseDTO.SubscriptionId);
            if (subscription == null)
            {
                return BadRequest("Invalid subscription ID.");
            }

            var course = new Course
            {
                ID = courseDTO.ID,
                Name = courseDTO.Name,
                Description = courseDTO.Description,
                Duration = courseDTO.Duration,
                Capacity = courseDTO.Capacity,
                SubscriptionId = courseDTO.SubscriptionId,
                Subscription = subscription,
                TrainerId = courseDTO.Trainer.ID,
                Trainer = new Trainer
                {
                    ID = courseDTO.Trainer.ID,
                    Email = courseDTO.Trainer.Email,
                    Password = courseDTO.Trainer.Password,
                    PhoneNumber = courseDTO.Trainer.PhoneNumber,
                    Role = courseDTO.Trainer.Role,
                    Name = courseDTO.Trainer.Name,
                    LastName = courseDTO.Trainer.LastName,
                    Age = courseDTO.Trainer.Age,
                    Experience = courseDTO.Trainer.Experience,
                    Photo = courseDTO.Trainer.Photo,
                    Description = courseDTO.Trainer.Description
                }
            };

            _context.Entry(course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
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
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.ID == id);
        }
    }
}*/
