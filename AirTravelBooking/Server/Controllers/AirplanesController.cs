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
    public class AirplanesController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitofwork;

        //public AirplanesController(ApplicationDbContext context)
        public AirplanesController(IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitofwork = unitOfWork;
        }

        // GET: api/Airplanes
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Airplane>>> GetAirplanes()
        public async Task<IActionResult> GetAirplanes()
        {
            //return await _context.Airplanes.ToListAsync();
            var airplanes = await _unitofwork.Airplanes.GetAll();
            return Ok(airplanes);
        }

        // GET: api/Airplanes/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Airplane>> GetAirplane(int id)
        public async Task<IActionResult> GetAirplane(int id)
        {
            //var airplane = await _context.Airplanes.FindAsync(id);
            var airplane = await _unitofwork.Airplanes.Get(q => q.Id == id);

            if (airplane == null)
            {
                return NotFound();
            }

            return Ok(airplane);
        }

        // PUT: api/Airplanes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAirplane(int id, Airplane airplane)
        {
            if (id != airplane.Id)
            {
                return BadRequest();
            }

            //_context.Entry(airplane).State = EntityState.Modified;
            _unitofwork.Airplanes.Update(airplane);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitofwork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!AirplaneExists(id))
                if (!await AirplaneExists(id))
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

        // POST: api/Airplanes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Airplane>> PostAirplane(Airplane airplane)
        {
            //_context.Airplanes.Add(airplane);
            //await _context.SaveChangesAsync(); default to save
            await _unitofwork.Airplanes.Insert(airplane);
            await _unitofwork.Save(HttpContext);



            return CreatedAtAction("GetAirplane", new { id = airplane.Id }, airplane);
        }

        // DELETE: api/Airplanes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAirplane(int id)
        {
            //var airplane = await _context.Airplanes.FindAsync(id);
            var airplane = await _unitofwork.Airplanes.Get(q => q.Id == id);
            if (airplane == null)
            {
                return NotFound();
            }

            //_context.Airplanes.Remove(airplane);
            //await _context.SaveChangesAsync();
            await _unitofwork.Airplanes.Delete(id);
            await _unitofwork.Save(HttpContext);

            return NoContent();
        }

        //private bool AirplaneExists(int id)
        private async Task<bool> AirplaneExists(int id)
        {
            //return _context.Airplanes.Any(e => e.Id == id);
            var airplane = await _unitofwork.Airplanes.Get(q => q.Id == id);
            return airplane != null;
        }
    }
}
