using PersonsAPI.Entities;
using PersonsAPI.Models;

namespace PersonsAPI.Mappers
{
    public static class PersonMapper
    {
        public static PersonAPIModel From(this Person model)
        {
            return new PersonAPIModel
            {
                Id = model.Id,
                Name = model.Name,
                Phone = model.Phone,
                Email = model.Email,
                Address = model.Address,
                PostalZip = model.PostalZip,
                Country = model.Country
            };
        }

        public static Person To(this PersonAPIModel model)
        {
            return new Person
            {
                Id = model.Id,
                Name = model.Name,
                Phone = model.Phone,
                Email = model.Email,
                Address = model.Address,
                PostalZip = model.PostalZip,
                Country = model.Country
            };
        }
    }
}