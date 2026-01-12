using Microsoft.AspNetCore.Mvc;
using Szamonkeres.Models;

namespace Szamonkeres.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmtypesController : ControllerBase
    {
        public readonly CinemadbContext _context;
        public FilmtypesController(CinemadbContext context)
        {
            _context = context;
        }

        [HttpGet("11.Feladat")]
        public ActionResult GetFilmTypesWithMovies()
        {
            try
            {
                var types = _context.FilmTypes
                    .Select(t => new
                    {
                        t.TypeId,
                        t.TypeName,
                        Movies = t.Movies.Select(movie => new
                        {
                            movie.MovieId,
                            movie.Title,
                            movie.ReleaseDate,
                            movie.ActorId,
                            movie.FilmTypeId
                        })
                    })
                    .ToList();

                return Ok(types);
            }
            catch (Exception e)
            {
                return BadRequest(new { error = e.Message });
            }
        }

    }
}
