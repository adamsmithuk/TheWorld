using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheWorld.Models;

namespace TheWorld.Controllers.Api
{
    [Route("api/trips")]
    public class TripsController : Controller
    {
        private ILogger<TripsController> _logger;
        private IWorldRepository _repository;

        public TripsController(IWorldRepository repositry,
            ILogger<TripsController> logger)
        {
            _repository = repositry;

            _logger = logger;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            try { 
            var result = _repository.GetAllTrips();

            return Ok(Mapper.Map<IEnumerable<TripViewModel>>(result));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to gte all Trips: {ex}");

                return BadRequest($"Error occoured");
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] TripViewModel theTrip)
        {
            if(ModelState.IsValid)
            {
                // Save to Database
                var newTrip = Mapper.Map<Trip>(theTrip);
                _repository.AddTrip(newTrip);

                if(await _repository.SaveChangesAsync())
                {
                    return Created($"api/trips/{theTrip.Name}", Mapper.Map<TripViewModel>(newTrip));
                } else
                {
                    return BadRequest("Failed to save changes to the database");
                }
            }

            return BadRequest(ModelState);
        }
    }
}
