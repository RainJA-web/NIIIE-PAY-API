using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NIIEPayAPI.Data;
using NIIIE_PAY_API.Model;

namespace NIIEPayAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SavingsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SavingsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Savings.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var sa = await _context.Savings.FindAsync(id);
            if (sa == null) return NotFound();
            return Ok(sa);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Savings sa)
        {
            _context.Savings.Add(sa);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = sa.SavingId }, sa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Savings sa)
        {
            if (id != sa.SavingId) return BadRequest();

            _context.Entry(sa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var sa = await _context.Savings.FindAsync(id);
            if (sa == null) return NotFound();

            _context.Savings.Remove(sa);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
