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
    public class BaggagesController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitofwork;

        //public BaggagesController(ApplicationDbContext context)
        public BaggagesController(IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitofwork = unitOfWork;
        }

        // GET: api/Baggages
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Baggage>>> GetBaggages()
        public async Task<IActionResult> GetBaggages()
        {
            //return await _context.Baggages.ToListAsync();
            var baggages = await _unitofwork.Baggages.GetAll();
            return Ok(baggages);
        }

        // GET: api/Baggages/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Baggage>> GetBaggage(int id)
        public async Task<IActionResult> GetBaggage(int id)
        {
            //var baggage = await _context.Baggages.FindAsync(id);
            var baggage = await _unitofwork.Baggages.Get(q => q.Id == id);

            if (baggage == null)
            {
                return NotFound();
            }

            return Ok(baggage);
        }

        // PUT: api/Baggages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBaggage(int id, Baggage baggage)
        {
            if (id != baggage.Id)
            {
                return BadRequest();
            }

            //_context.Entry(baggage).State = EntityState.Modified;
            _unitofwork.Baggages.Update(baggage);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitofwork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!BaggageExists(id))
                if (!await BaggageExists(id))
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

        // POST: api/Baggages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Baggage>> PostBaggage(Baggage baggage)
        {
            //_context.Baggages.Add(baggage);
            //await _context.SaveChangesAsync(); default to save
            await _unitofwork.Baggages.Insert(baggage);
            await _unitofwork.Save(HttpContext);



            return CreatedAtAction("GetBaggage", new { id = baggage.Id }, baggage);
        }

        // DELETE: api/Baggages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBaggage(int id)
        {
            //var baggage = await _context.Baggages.FindAsync(id);
            var baggage = await _unitofwork.Baggages.Get(q => q.Id == id);
            if (baggage == null)
            {
                return NotFound();
            }

            //_context.Baggages.Remove(baggage);
            //await _context.SaveChangesAsync();
            await _unitofwork.Baggages.Delete(id);
            await _unitofwork.Save(HttpContext);

            return NoContent();
        }

        //private bool BaggageExists(int id)
        private async Task<bool> BaggageExists(int id)
        {
            //return _context.Baggages.Any(e => e.Id == id);
            var baggage = await _unitofwork.Baggages.Get(q => q.Id == id);
            return baggage != null;
        }
    }
}
