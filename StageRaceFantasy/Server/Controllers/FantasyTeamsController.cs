using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StageRaceFantasy.Server.Db;
using StageRaceFantasy.Shared.Models;

namespace StageRaceFantasy.Server.Controllers
{
    [Route("api/fantasy-teams")]
    [ApiController]
    public class FantasyTeamsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FantasyTeamsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FantasyTeam>>> GetFantasyTeams()
        {
            return await _context.FantasyTeams.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FantasyTeam>> GetFantasyTeam(int id)
        {
            var fantasyTeam = await _context.FantasyTeams.FindAsync(id);

            if (fantasyTeam == null)
            {
                return NotFound();
            }

            return fantasyTeam;
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFantasyTeam(int id, FantasyTeam fantasyTeam)
        {
            if (id != fantasyTeam.Id)
            {
                return BadRequest();
            }

            _context.Entry(fantasyTeam).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FantasyTeamExists(id))
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

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FantasyTeam>> PostFantasyTeam(FantasyTeam fantasyTeam)
        {
            _context.FantasyTeams.Add(fantasyTeam);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFantasyTeam", new { id = fantasyTeam.Id }, fantasyTeam);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFantasyTeam(int id)
        {
            var fantasyTeam = await _context.FantasyTeams.FindAsync(id);
            if (fantasyTeam == null)
            {
                return NotFound();
            }

            _context.FantasyTeams.Remove(fantasyTeam);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FantasyTeamExists(int id)
        {
            return _context.FantasyTeams.Any(e => e.Id == id);
        }
    }
}
