using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IIS.Model;
using IIS.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace IIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : DefaultController
    {
        FlightService service = new FlightService();

        public FlightController(IConfiguration config) : base(config)
        {
        }


        [HttpPost]
        [Route("/api/flights")]
        public async Task<IActionResult> AddFlight(Flight flightData)
        {
            Flight flight = service.CreateFlight(flightData);

            if (flight == null)
            {
                return BadRequest();
            }

            return Ok(flight);
        }

        [Authorize]
        [HttpPost]
        [Route("/api/flight/edit")]
        public async Task<IActionResult> EditFlight(Flight flightData)
        {
            Flight flight = service.EditFlight(flightData);

            if(flight == null)
            {
                return BadRequest();
            }

            return Ok(flight);
        }
        [HttpGet]
        [Route("/api/flights/get-all")]
        public async Task<IActionResult> AllFlights()
        {
            IEnumerable<Flight> flights = service.GetAllFlights();

            if(flights == null)
            {
                return BadRequest();
            }

            return Ok(flights);
        }

        [HttpPost]
        [Route("/api/flightAdditionals")]
        public async Task<IActionResult> AddFlightAdditional(FlightAdditionals data)
        {
            FlightAdditionals flightAdditionals = service.CreateFlightAdditionals(data);

            if(flightAdditionals == null)
            {
                return BadRequest();
            }

            return Ok(flightAdditionals);
        }

        [HttpPut]
        [Route("/api/flightAdditionals")]
        public async Task<IActionResult> EditFlightAdditional(FlightAdditionals data)
        {
            FlightAdditionals flightAdditionals = service.EditFlightAdditionals(data);

            if (flightAdditionals == null)
            {
                return BadRequest();
            }

            return Ok(flightAdditionals);
        }

        [HttpGet]
        [Route("/api/flightAdditionals/get-all")]
        public async Task<IActionResult> AllFlightAdditionals()
        {
            IEnumerable<FlightAdditionals> flightAdditionals = service.GetAllFlightAdditionals();

            if (flightAdditionals == null)
            {
                return BadRequest();
            }

            return Ok(flightAdditionals);
        }

        [HttpPost]
        [Route("/api/airports")]
        public async Task<IActionResult> AddAirport(Airport data)
        {
            Airport airport = service.CreateAirport(data);

            if(airport == null)
            {
                return BadRequest();
            }

            return Ok(airport);
        }

        [HttpPut]
        [Route("/api/airports")]
        public async Task<IActionResult> EditAirport(Airport data)
        {
            Airport airport = service.EditAirport(data);

            if (airport == null)
            {
                return BadRequest();
            }

            return Ok(airport);
        }

        [HttpGet]
        [Route("/api/airports/get-all")]
        public async Task<IActionResult> AllAirports()
        {
            IEnumerable<Airport> airports = service.GetAllAirports();

            if (airports == null)
            {
                return BadRequest();
            }

            return Ok(airports);
        }

        [HttpPost]
        [Route("/api/airplanes")]
        public async Task<IActionResult> AddAirplane(Airplane data)
        {
            Airplane airplane = service.CreateAirplane(data);

            if(airplane == null)
            {
                return BadRequest();
            }

            return Ok(airplane);
        }

        [HttpPut]
        [Route("/api/airplanes")]
        public async Task<IActionResult> EditAirplane(Airplane data)
        {
            Airplane airplane = service.EditAirplane(data);

            if (airplane == null)
            {
                return BadRequest();
            }

            return Ok(airplane);
        }

        [HttpGet]
        [Route("/api/airplanes/get-all")]
        public async Task<IActionResult> AllAirplanes()
        {
            IEnumerable<Airplane> airplanes = service.GetAllAirplanes();

            if (airplanes == null)
            {
                return BadRequest();
            }

            return Ok(airplanes);
        }

        [HttpGet]
        [Route("/api/additionals/get-all")]
        public async Task<IActionResult> GetAdditionals()
        {
            IEnumerable<FlightAdditionals> flightAdditionals = service.GetAllFlightAdditionals();

            return Ok(flightAdditionals);
        }

        [HttpDelete]
        [Route("/api/flights/{id}")]
        public async Task<IActionResult> DeleteFlight(int id)
        {
            service.DeleteFlight(id);

            return Ok();
        }

        [HttpDelete]
        [Route("/api/airports/{id}")]
        public async Task<IActionResult> DeleteAirport(int id)
        {
            service.DeleteAirport(id);

            return Ok();
        }

        [HttpDelete]
        [Route("/api/airplanes/{id}")]
        public async Task<IActionResult> DeleteAirplane(int id)
        {
            service.DeleteAirplane(id);

            return Ok();
        }
    }
}
