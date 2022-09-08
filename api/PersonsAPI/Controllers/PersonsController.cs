using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonsAPI.Data;
using PersonsAPI.Mappers;
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
        public async Task<BaseApiResponse<IReadOnlyList<PersonAPIModel>>> GetAllPersons()
        {
            var persons = await _context.Persons.ToListAsync();
            var model = persons
                .Select(x => PersonMapper.From(x))
                .ToList();

            var response = new BaseApiResponse<IReadOnlyList<PersonAPIModel>>
            {
                Data = model,
                IsSuccess = true,
                StatusCode = HttpStatusCode.OK,
                Message = "Success",
                Errors = null
            };

            return response;
        }

        [HttpGet]
        [Route("GetPersonById/{id:Guid}")]
        public async Task<BaseApiResponse<PersonAPIModel>> GetPersonById([FromRoute] Guid id)
        {
            var person = await _context.Persons
                .FirstOrDefaultAsync(x => x.Id == id);

            if (person == null)
            {
                return new BaseApiResponse<PersonAPIModel>()
                {
                    Data = null,
                    IsSuccess = false,
                    Errors = null,
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Not Found"
                };
            }

            var response = new BaseApiResponse<PersonAPIModel>
            {
                Data = PersonMapper.From(person),
                IsSuccess = true,
                StatusCode = HttpStatusCode.OK,
                Message = "Success",
                Errors = null
            };

            return response;
        }

        [HttpPost]
        [Route("CreatePerson")]
        public async Task<BaseApiResponse<PersonAPIModel>> CreatePerson([FromBody] PersonAPIModel person)
        {
            var model = await _context.Persons
                .FirstOrDefaultAsync(x => x.Email == person.Email);

            if (model != null)
            {
                return new BaseApiResponse<PersonAPIModel>()
                {
                    Data = null,
                    IsSuccess = false,
                    Errors = null,
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Person already exists"
                };
            }
            _context.Persons.Add(PersonMapper.To(person));
            await _context.SaveChangesAsync();

            return new BaseApiResponse<PersonAPIModel>()
            {
                Data = person,
                IsSuccess = true,
                Errors = null,
                StatusCode = HttpStatusCode.Created,
                Message = "Created"
            };
        }

        [HttpPut]
        [Route("UpdatePerson")]
        public async Task<BaseApiResponse<PersonAPIModel>> UpdatePerson([FromBody] PersonAPIModel person)
        {
            var model = await _context.Persons
                .FirstOrDefaultAsync(x => x.Id == person.Id);

            if (model == null)
            {
                return new BaseApiResponse<PersonAPIModel>()
                {
                    Data = null,
                    IsSuccess = false,
                    Errors = null,
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Person not exists"
                };
            }

            model.Name = person.Name;
            model.Phone = person.Phone;
            model.Email = person.Email;
            model.Address = person.Address;
            model.PostalZip = person.PostalZip;
            model.Country = person.Country;

            _context.Persons.Update(model);
            await _context.SaveChangesAsync();

            return new BaseApiResponse<PersonAPIModel>()
            {
                Data = PersonMapper.From(model),
                IsSuccess = true,
                Errors = null,
                StatusCode = HttpStatusCode.OK,
                Message = "Updated"
            };
        }

        [HttpDelete]
        [Route("DeletePerson")]
        public async Task<BaseApiResponse<PersonAPIModel>> DeletePerson([FromBody] Guid id)
        {
            var model = await _context.Persons
                .FirstOrDefaultAsync(x => x.Id == id);

            if (model == null)
            {
                return new BaseApiResponse<PersonAPIModel>()
                {
                    Data = null,
                    IsSuccess = false,
                    Errors = null,
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Person not exists"
                };
            }

            _context.Persons.Remove(model);
            await _context.SaveChangesAsync();

            return new BaseApiResponse<PersonAPIModel>()
            {
                Data = null,
                IsSuccess = true,
                Errors = null,
                StatusCode = HttpStatusCode.OK,
                Message = "Deleted"
            };
        }
    }
}