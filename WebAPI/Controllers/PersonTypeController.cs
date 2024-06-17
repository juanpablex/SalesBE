using Business.Repositories.PersonTypeRepository;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonTypesController : ControllerBase
    {
        private readonly IPersonTypeService _persontypeService;

        public PersonTypesController(IPersonTypeService persontypeService)
        {
            _persontypeService = persontypeService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult>Add(PersonType persontype)
        {
            var result = await _persontypeService.Add(persontype);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update(PersonType persontype)
        {
            var result = await _persontypeService.Update(persontype);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Delete(PersonType persontype)
        {
            var result = await _persontypeService.Delete(persontype);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _persontypeService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _persontypeService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
