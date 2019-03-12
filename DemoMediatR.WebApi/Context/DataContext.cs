using Microsoft.EntityFrameworkCore;
using DemoMediatR.WebApi.Domain;

namespace DemoMediatR.WebApi.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Person> Persons{get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("Person");
        }
    }
}