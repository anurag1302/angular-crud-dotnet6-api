using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonsAPI.Data;
using PersonsAPI.Entities;
using PersonsAPI.Models;
using System.Net;

namespace PersonsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly PersonsDBContext _context;

        public PersonsController(PersonsDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetAllPersons")]
        public async Task<BaseApiResponse<IReadOnlyList<Person>>> GetAllPersons()
        {
            var response = new BaseApiResponse<IReadOnlyList<Person>>
            {
                Data = await _context.Persons.ToListAsync(),
                IsSuccess = true,
                StatusCode = HttpStatusCode.OK,
                Message = "Success",
                Errors = null
            };

            return response;
        }

        [HttpGet]
        [Route("GetPersonById/{id}")]
        public async Task<BaseApiResponse<Person>> GetPersonById(Guid id)
        {
            var person = await _context.Persons.FirstOrDefaultAsync(x => x.Id == id);

            if (person == null)
            {
                return new BaseApiResponse<Person>()
                {
                    Data = null,
                    IsSuccess = false,
                    Errors = null,
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Not Found"
                };
            }

            var response = new BaseApiResponse<Person>
            {
                Data = person,
                IsSuccess = true,
                StatusCode = HttpStatusCode.OK,
                Message = "Success",
                Errors = null
            };

            return response;
        }
    }
}