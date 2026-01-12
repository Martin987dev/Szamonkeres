using Microsoft.AspNetCore.Mvc;
using Szamonkeres.Models;

namespace Szamonkeres.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly CinemadbContext _context;
        public MoviesController(CinemadbContext context)
        {
            _context = context;
        }

        [HttpGet("10.Feladat")]
        public ActionResult GetMovies()
        {
            try
            {
                var movieList = _context.Movies
                    .Select(movie => new
                    {
                        movie.MovieId,
                        movie.Title,
                        movie.ReleaseDate,
                        movie.ActorId,
                        movie.FilmTypeId
                    })
                    .ToList();

                return Ok(movieList);
            }
            catch (Exception e)
            {
                return BadRequest(new { error = e.Message });
            }
        }

    }
}
