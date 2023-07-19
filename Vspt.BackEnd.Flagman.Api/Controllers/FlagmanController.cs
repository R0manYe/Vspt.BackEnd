using Microsoft.AspNetCore.Mvc;
using Vspt.BackEnd.Flagman.Infrastructure.Database;


namespace Vspt.BackEnd.Flagman.Api.Controllers
{
    public class FlagmanController : ControllerBase
    {
        private readonly FlagmanContext _context;

        public FlagmanController(FlagmanContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult> Get()
        {
            var result = await _context.Dislokacia.AsNoTracking().ToListAsync();
            return Ok(result);


        }
    }
}
