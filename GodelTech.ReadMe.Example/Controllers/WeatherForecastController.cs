using System.Threading.Tasks;
using GodelTech.Microservices.EntityFrameworkCore.Repositories;
using GodelTech.ReadMe.Example.Data.Entities;
using GodelTech.ReadMe.Example.Data.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace GodelTech.ReadMe.Example.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IRepository<Precipitation> _precipitationRepository;

        public WeatherForecastController(IRepository<Precipitation> precipitationRepository)
        {
            _precipitationRepository = precipitationRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Precipitation precipitation = await _precipitationRepository.GetByIdAsync(id);

            return Ok(precipitation);
        }

        [HttpGet("temperature/{temperature}/town/{town}")]
        public async Task<IActionResult> GetList(int temperature, string town)
        {
            var spec = new PrecipitationSpecification
            {
                Temperature = temperature,
                Town = town,
                IncludePrecipitationType = true
            };

            var precipitations = await _precipitationRepository.ListAsync(spec);

            return Ok(precipitations);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Precipitation precipitation = await _precipitationRepository.GetByIdAsync(id);

            await _precipitationRepository.DeleteAsync(precipitation);

            return Ok();
        }


    }
}
