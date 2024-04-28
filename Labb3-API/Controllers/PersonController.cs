using Labb3_API.Models;
using Labb3_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Labb3_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        [HttpGet("AllPersons")]
        public async Task<ActionResult<Person>> GetAllPerson()
        {
            try
            {
                return Ok(await _personRepository.GetAll());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to get all persons from Database..");
            }
        }

        [HttpGet("GetPersonInterest/{id:int}")]
        public async Task<ActionResult<Person>> GetInterestById(int id)
        {
            try
            {
                var result = await _personRepository.GetPersonByInterest(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to get interest by ID..");
            }
        }


        [HttpGet("GetPersonLinks/{Id:int}")]
        public async Task<ActionResult<Person>> GetLinkById(int Id)
        {
            try
            {
                var result = await _personRepository.GetPersonByLinks(Id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to get link by ID..");
            }
        }

        [HttpPost("AddInterest")]
        public async Task<IActionResult> AddInterestToId(int personID, int interest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                await _personRepository.AddInterestToPerson(personID, interest);
                return Ok();

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to add interest to ID..");
            }
        }

        [HttpPost("AddLink")]
        public async Task<IActionResult> AddLinkToId(int personID, int interestID, string url)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                await _personRepository.AddLinkToPerson(personID, interestID, url);
                return Ok();
            }
            catch
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to add link to ID..");
            }
        }
    }
}