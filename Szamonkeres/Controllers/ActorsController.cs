using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Szamonkeres.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly Models.CinemadbContext _context;
        public ActorsController(Models.CinemadbContext context)
        {
            _context = context;
        }
    
        [HttpGet("12.Feladat")]
        public ActionResult GetActorCount()
        {
            try
            {
                int actorCount = _context.Actors.Count();
                return Ok($"A színészek számq: {actorCount}");
            }
            catch (Exception e)
            {
                return BadRequest(new { error = e.Message });
            }
        }

    }
}
