using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PersonDetails.Models;
using PersonDetails.Services;

namespace idealrating.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonDetailsController : ControllerBase
    {
       
        private readonly ILogger<PersonDetailsController> _logger;

        private readonly IPersonService _personSrv;


        public PersonDetailsController(ILogger<PersonDetailsController> logger, IPersonService personSrv)
        {
            _personSrv = personSrv;
            _logger = logger;
           
        }

        [HttpGet]
        public IActionResult GetPersons([FromQuery] string? filter)
        {
            _logger.LogInformation("GetPersons called with filter: {Filter}", filter);
            try
            {

                var persons = _personSrv.GetPersons(filter).Result;
                return Ok(persons);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting persons with filter: {Filter}", filter);
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.ToString() });
            }
        }
    }
}
