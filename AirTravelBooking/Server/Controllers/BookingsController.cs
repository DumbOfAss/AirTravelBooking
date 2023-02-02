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
    public class BookingsController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitofwork;

        //public BookingsController(ApplicationDbContext context)
        public BookingsController(IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitofwork = unitOfWork;
        }

        // GET: api/Bookings
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
        public async Task<IActionResult> GetBookings()
        {
            //return await _context.Bookings.ToListAsync();
            var bookings = await _unitofwork.Bookings.GetAll();
            return Ok(bookings);
        }

        // GET: api/Bookings/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Booking>> GetBooking(int id)
        public async Task<IActionResult> GetBooking(int id)
        {
            //var booking = await _context.Bookings.FindAsync(id);
            var booking = await _unitofwork.Bookings.Get(q => q.Id == id);

            if (booking == null)
            {
                return NotFound();
            }

            return Ok(booking);
        }

        // PUT: api/Bookings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooking(int id, Booking booking)
        {
            if (id != booking.Id)
            {
                return BadRequest();
            }

            //_context.Entry(booking).State = EntityState.Modified;
            _unitofwork.Bookings.Update(booking);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitofwork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!BookingExists(id))
                if (!await BookingExists(id))
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

        // POST: api/Bookings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Booking>> PostBooking(Booking booking)
        {
            //_context.Bookings.Add(booking);
            //await _context.SaveChangesAsync(); default to save
            await _unitofwork.Bookings.Insert(booking);
            await _unitofwork.Save(HttpContext);



            return CreatedAtAction("GetBooking", new { id = booking.Id }, booking);
        }

        // DELETE: api/Bookings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            //var booking = await _context.Bookings.FindAsync(id);
            var booking = await _unitofwork.Bookings.Get(q => q.Id == id);
            if (booking == null)
            {
                return NotFound();
            }

            //_context.Bookings.Remove(booking);
            //await _context.SaveChangesAsync();
            await _unitofwork.Bookings.Delete(id);
            await _unitofwork.Save(HttpContext);

            return NoContent();
        }

        //private bool BookingExists(int id)
        private async Task<bool> BookingExists(int id)
        {
            //return _context.Bookings.Any(e => e.Id == id);
            var booking = await _unitofwork.Bookings.Get(q => q.Id == id);
            return booking != null;
        }
    }
}
