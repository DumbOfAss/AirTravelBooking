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
    public class DestinationsController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitofwork;

        //public DestinationsController(ApplicationDbContext context)
        public DestinationsController(IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitofwork = unitOfWork;
        }

        // GET: api/Destinations
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Destination>>> GetDestinations()
        public async Task<IActionResult> GetDestinations()
        {
            //return await _context.Destinations.ToListAsync();
            var destinations = await _unitofwork.Destinations.GetAll();
            return Ok(destinations);
        }

        // GET: api/Destinations/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Destination>> GetDestination(int id)
        public async Task<IActionResult> GetDestination(int id)
        {
            //var destination = await _context.Destinations.FindAsync(id);
            var destination = await _unitofwork.Destinations.Get(q => q.Id == id);

            if (destination == null)
            {
                return NotFound();
            }

            return Ok(destination);
        }

        // PUT: api/Destinations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDestination(int id, Destination destination)
        {
            if (id != destination.Id)
            {
                return BadRequest();
            }

            //_context.Entry(destination).State = EntityState.Modified;
            _unitofwork.Destinations.Update(destination);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitofwork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!DestinationExists(id))
                if (!await DestinationExists(id))
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

        // POST: api/Destinations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Destination>> PostDestination(Destination destination)
        {
            //_context.Destinations.Add(destination);
            //await _context.SaveChangesAsync(); default to save
            await _unitofwork.Destinations.Insert(destination);
            await _unitofwork.Save(HttpContext);



            return CreatedAtAction("GetDestination", new { id = destination.Id }, destination);
        }

        // DELETE: api/Destinations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDestination(int id)
        {
            //var destination = await _context.Destinations.FindAsync(id);
            var destination = await _unitofwork.Destinations.Get(q => q.Id == id);
            if (destination == null)
            {
                return NotFound();
            }

            //_context.Destinations.Remove(destination);
            //await _context.SaveChangesAsync();
            await _unitofwork.Destinations.Delete(id);
            await _unitofwork.Save(HttpContext);

            return NoContent();
        }

        //private bool DestinationExists(int id)
        private async Task<bool> DestinationExists(int id)
        {
            //return _context.Destinations.Any(e => e.Id == id);
            var destination = await _unitofwork.Destinations.Get(q => q.Id == id);
            return destination != null;
        }
    }
}
