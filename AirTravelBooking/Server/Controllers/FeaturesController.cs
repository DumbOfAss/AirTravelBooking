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
    public class FeaturesController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitofwork;

        //public FeaturesController(ApplicationDbContext context)
        public FeaturesController(IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitofwork = unitOfWork;
        }

        // GET: api/Features
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Feature>>> GetFeatures()
        public async Task<IActionResult> GetFeatures()
        {
            //return await _context.Features.ToListAsync();
            var features = await _unitofwork.Features.GetAll();
            return Ok(features);
        }

        // GET: api/Features/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Feature>> GetFeature(int id)
        public async Task<IActionResult> GetFeature(int id)
        {
            //var feature = await _context.Features.FindAsync(id);
            var feature = await _unitofwork.Features.Get(q => q.Id == id);

            if (feature == null)
            {
                return NotFound();
            }

            return Ok(feature);
        }

        // PUT: api/Features/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeature(int id, Feature feature)
        {
            if (id != feature.Id)
            {
                return BadRequest();
            }

            //_context.Entry(feature).State = EntityState.Modified;
            _unitofwork.Features.Update(feature);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitofwork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!FeatureExists(id))
                if (!await FeatureExists(id))
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

        // POST: api/Features
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Feature>> PostFeature(Feature feature)
        {
            //_context.Features.Add(feature);
            //await _context.SaveChangesAsync(); default to save
            await _unitofwork.Features.Insert(feature);
            await _unitofwork.Save(HttpContext);
            


            return CreatedAtAction("GetFeature", new { id = feature.Id }, feature);
        }

        // DELETE: api/Features/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeature(int id)
        {
            //var feature = await _context.Features.FindAsync(id);
            var feature = await _unitofwork.Features.Get(q => q.Id == id);
            if (feature == null)
            {
                return NotFound();
            }

            //_context.Features.Remove(feature);
            //await _context.SaveChangesAsync();
            await _unitofwork.Features.Delete(id);
            await _unitofwork.Save(HttpContext);

            return NoContent();
        }

        //private bool FeatureExists(int id)
        private async Task<bool> FeatureExists(int id)
        {
            //return _context.Features.Any(e => e.Id == id);
            var feature = await _unitofwork.Features.Get(q => q.Id == id);
            return feature != null;
        }
    }
}
