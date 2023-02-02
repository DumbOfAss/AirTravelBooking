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
    public class SeatsController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitofwork;

        //public SeatsController(ApplicationDbContext context)
        public SeatsController(IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitofwork = unitOfWork;
        }

        // GET: api/Seats
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Seat>>> GetSeats()
        public async Task<IActionResult> GetSeats()
        {
            //return await _context.Seats.ToListAsync();
            var seats = await _unitofwork.Seats.GetAll();
            return Ok(seats);
        }

        // GET: api/Seats/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Seat>> GetSeat(int id)
        public async Task<IActionResult> GetSeat(int id)
        {
            //var seat = await _context.Seats.FindAsync(id);
            var seat = await _unitofwork.Seats.Get(q => q.Id == id);

            if (seat == null)
            {
                return NotFound();
            }

            return Ok(seat);
        }

        // PUT: api/Seats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeat(int id, Seat seat)
        {
            if (id != seat.Id)
            {
                return BadRequest();
            }

            //_context.Entry(seat).State = EntityState.Modified;
            _unitofwork.Seats.Update(seat);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitofwork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!SeatExists(id))
                if (!await SeatExists(id))
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

        // POST: api/Seats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Seat>> PostSeat(Seat seat)
        {
            //_context.Seats.Add(seat);
            //await _context.SaveChangesAsync(); default to save
            await _unitofwork.Seats.Insert(seat);
            await _unitofwork.Save(HttpContext);
            


            return CreatedAtAction("GetSeat", new { id = seat.Id }, seat);
        }

        // DELETE: api/Seats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeat(int id)
        {
            //var seat = await _context.Seats.FindAsync(id);
            var seat = await _unitofwork.Seats.Get(q => q.Id == id);
            if (seat == null)
            {
                return NotFound();
            }

            //_context.Seats.Remove(seat);
            //await _context.SaveChangesAsync();
            await _unitofwork.Seats.Delete(id);
            await _unitofwork.Save(HttpContext);

            return NoContent();
        }

        //private bool SeatExists(int id)
        private async Task<bool> SeatExists(int id)
        {
            //return _context.Seats.Any(e => e.Id == id);
            var seat = await _unitofwork.Seats.Get(q => q.Id == id);
            return seat != null;
        }
    }
}
