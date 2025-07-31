using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NIIEPayAPI.Data;
using NIIIE_PAY_API.Model;

namespace NIIEPayAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestRatesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InterestRatesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/InterestRates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InterestRate>>> GetInterestRates()
        {
            return await _context.InterestRates.ToListAsync();
        }

        // GET: api/InterestRates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InterestRate>> GetInterestRate(int id)
        {
            var rate = await _context.InterestRates.FindAsync(id);

            if (rate == null)
                return NotFound();

            return rate;
        }

        // POST: api/InterestRates
        [HttpPost]
        public async Task<ActionResult<InterestRate>> PostInterestRate(InterestRate rate)
        {
            _context.InterestRates.Add(rate);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetInterestRate), new { id = rate.Id }, rate);
        }

        // PUT: api/InterestRates/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInterestRate(int id, InterestRate rate)
        {
            if (id != rate.Id)
                return BadRequest();

            _context.Entry(rate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.InterestRates.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/InterestRates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInterestRate(int id)
        {
            var rate = await _context.InterestRates.FindAsync(id);
            if (rate == null)
                return NotFound();

            _context.InterestRates.Remove(rate);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
