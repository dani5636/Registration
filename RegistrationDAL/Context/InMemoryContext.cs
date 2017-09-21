using Microsoft.EntityFrameworkCore;
using RegistrationDAL.Entities;

namespace RegistrationDAL.Context
{
    class InMemoryContext : DbContext
    {
        static DbContextOptions<InMemoryContext> options =
            new DbContextOptionsBuilder<InMemoryContext>().UseInMemoryDatabase("TheDB").Options;

        //Show that we want to have it in memory
        public InMemoryContext() : base(options)
        {

        }
        public DbSet<Video> Videos { get; set; }
    }
}
