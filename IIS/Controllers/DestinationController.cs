using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IIS.Model;
using IIS.Model.Request;
using IIS.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace IIS.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DestinationController : DefaultController
    {
        DestinationService service = new DestinationService();

        public DestinationController(IConfiguration config) : base(config)
        {
        }



        [HttpPost]
        [Route("/api/destinations")]
        public async Task<IActionResult> CreateDestination(Destination data)
        {
            Destination destination = service.CreateDestination(data);

            if (destination == null)
            {
                return BadRequest();
            }

            return Ok(destination);
        }

        [HttpPut]
        [Route("/api/destinations")]
        public async Task<IActionResult> EditDestination(Destination data)
        {
            Destination destination = service.EditDestination(data);

            if (destination == null)
            {
                return BadRequest();
            }

            return Ok(destination);
        }


        [HttpGet]
        [Route("/api/destinations/get-all")]
        public async Task<IActionResult> AllDestinations()
        {
            IEnumerable<Destination> destinations = service.GetAllDestinations();

            if (destinations == null)
            {
                return BadRequest();
            }

            return Ok(destinations);
        }


        [HttpPost]
        [Route("/api/countries")]
        public async Task<IActionResult> CreateCountry(Country data)
        {
            Country country = service.CreateCountry(data);

            if (country == null)
            {
                return BadRequest();
            }

            return Ok(country);
        }

        [HttpPut]
        [Route("/api/countries")]
        public async Task<IActionResult> EditCountry(Country data)
        {
            Country country = service.EditCountry(data);

            if (country == null)
            {
                return BadRequest();
            }

            return Ok(country);
        }

        [HttpGet]
        [Route("/api/countries/get-all")]
        public async Task<IActionResult> AllCountries()
        {
            IEnumerable<Country> countries = service.GetAllCountries();

            if (countries == null)
            {
                return BadRequest();
            }

            return Ok(countries);
        }


        [HttpPost]
        [Route("/api/cities")]
        public async Task<IActionResult> CreateCity(City data)
        {
            City city = service.CreateCity(data);

            if (city == null)
            {
                return BadRequest();
            }

            return Ok(city);
        }

        [HttpPut]
        [Route("/api/cities")]
        public async Task<IActionResult> EditCity(City data)
        {
            City city = service.EditCity(data);

            if (city == null)
            {
                return BadRequest();
            }

            return Ok(city);
        }

        [HttpGet]
        [Route("/api/cities/get-all")]
        public async Task<IActionResult> AllCities()
        {
            IEnumerable<City> cities = service.GetAllCities();

            if (cities == null)
            {
                return BadRequest();
            }

            return Ok(cities);
        }

        [HttpPost]
        [Route("/api/additionals/create-purAd")]
        public async Task<IActionResult> CreatePurAd(PurchersAdditionalsRequest data)
        {
            PurchesersAdditionals purchesersAdditionals = service.CreatePurcherseAdd(data);

            if (purchesersAdditionals == null)
            {
                return BadRequest();
            }

            return Ok(purchesersAdditionals);
        }

        [HttpDelete]
        [Route("/api/destinations/{id}")]
        public async Task<IActionResult> DeleteDestination(int id)
        {
            service.DeleteDestination(id);

            return Ok();
        }

        [HttpDelete]
        [Route("/api/cities/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            service.DeleteCity(id);

            return Ok();
        }

        [HttpDelete]
        [Route("/api/countries/{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            service.DeleteCountry(id);

            return Ok();
        }

        [HttpDelete]
        [Route("/api/additionals/{id}")]
        public async Task<IActionResult> DeleteAdditionals(int id)
        {
            service.DeleteAdditionals(id);

            return Ok();
        }
    }

}