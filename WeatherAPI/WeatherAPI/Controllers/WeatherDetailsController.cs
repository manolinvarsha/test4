using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeatherAPI.Models;

namespace WeatherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherDetailsController : ControllerBase
    {
        private readonly WeatherContext _context;

        public WeatherDetailsController(WeatherContext context)
        {
            _context = context;
        }

        // GET: api/WeatherDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeatherDetails>>> GetWeatherForecast()
        {
            return await _context.WeatherForecast.ToListAsync();
        }

        // GET: api/WeatherDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WeatherDetails>> GetWeatherDetails(string id)
        {
            var weatherDetails = await _context.WeatherForecast.FindAsync(id);

            if (weatherDetails == null)
            {
                return NotFound();
            }

            return weatherDetails;
        }

        // PUT: api/WeatherDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeatherDetails(string id, WeatherDetails weatherDetails)
        {
            if (id != weatherDetails.City)
            {
                return BadRequest();
            }

            _context.Entry(weatherDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeatherDetailsExists(id))
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

        // POST: api/WeatherDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WeatherDetails>> PostWeatherDetails(WeatherDetails weatherDetails)
        {
            _context.WeatherForecast.Add(weatherDetails);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (WeatherDetailsExists(weatherDetails.City))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetWeatherDetails", new { id = weatherDetails.City }, weatherDetails);
        }

        // DELETE: api/WeatherDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeatherDetails(string id)
        {
            var weatherDetails = await _context.WeatherForecast.FindAsync(id);
            if (weatherDetails == null)
            {
                return NotFound();
            }

            _context.WeatherForecast.Remove(weatherDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WeatherDetailsExists(string id)
        {
            return _context.WeatherForecast.Any(e => e.City == id);
        }
    }
}
