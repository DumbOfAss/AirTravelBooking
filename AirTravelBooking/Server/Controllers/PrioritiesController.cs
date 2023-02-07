using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AirTravelBooking.Server.Data;
using AirTravelBooking.Shared.Domain;
using AirTravelBooking.Server.IRepository;

namespace AirTravelBooking.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrioritiesController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitofwork;

        //public PrioritiesController(ApplicationDbContext context)
        public PrioritiesController(IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitofwork = unitOfWork;
        }

        // GET: api/Priorities
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Priority>>> GetPriorities()
        public async Task<IActionResult> GetPriorities()
        {
            //return await _context.Priorities.ToListAsync();
            var priorities = await _unitofwork.Priorities.GetAll(includes: q => q.Include(x=>x.Feature));
            return Ok(priorities);
        }

        // GET: api/Priorities/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Priority>> GetPriority(int id)
        public async Task<IActionResult> GetPriority(int id)
        {
            //var priority = await _context.Priorities.FindAsync(id);
            var priority = await _unitofwork.Priorities.Get(q => q.Id == id);

            if (priority == null)
            {
                return NotFound();
            }

            return Ok(priority);
        }

        // PUT: api/Priorities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPriority(int id, Priority priority)
        {
            if (id != priority.Id)
            {
                return BadRequest();
            }

            //_context.Entry(priority).State = EntityState.Modified;
            _unitofwork.Priorities.Update(priority);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitofwork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!PriorityExists(id))
                if (!await PriorityExists(id))
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

        // POST: api/Priorities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Priority>> PostPriority(Priority priority)
        {
            //_context.Priorities.Add(priority);
            //await _context.SaveChangesAsync(); default to save
            await _unitofwork.Priorities.Insert(priority);
            await _unitofwork.Save(HttpContext);



            return CreatedAtAction("GetPriority", new { id = priority.Id }, priority);
        }

        // DELETE: api/Priorities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePriority(int id)
        {
            //var priority = await _context.Priorities.FindAsync(id);
            var priority = await _unitofwork.Priorities.Get(q => q.Id == id);
            if (priority == null)
            {
                return NotFound();
            }

            //_context.Priorities.Remove(priority);
            //await _context.SaveChangesAsync();
            await _unitofwork.Priorities.Delete(id);
            await _unitofwork.Save(HttpContext);

            return NoContent();
        }

        //private bool PriorityExists(int id)
        private async Task<bool> PriorityExists(int id)
        {
            //return _context.Priorities.Any(e => e.Id == id);
            var priority = await _unitofwork.Priorities.Get(q => q.Id == id);
            return priority != null;
        }
    }
}
