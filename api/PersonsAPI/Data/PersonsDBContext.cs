using Microsoft.EntityFrameworkCore;
using PersonsAPI.Entities;

namespace PersonsAPI.Data
{
    public class PersonsDBContext : DbContext
    {
        public PersonsDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
    }
}