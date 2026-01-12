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
    }
}
