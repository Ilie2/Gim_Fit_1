using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Gimfit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProtectedController : ControllerBase
    {
        [Authorize]
        [HttpGet("example")]
        public IActionResult Example()
        {
            // Doar utilizatorii autentificați pot accesa această rută
            return Ok("You accessed a protected route!");
        }
    }
}
