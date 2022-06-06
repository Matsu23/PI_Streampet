using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using StreamPet.Models;

namespace StreamPet.Models
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<PetService> PetServices { get; set; }

        public DbSet<StreamPet.Models.Usuario>? Usuario { get; set; }
    }
}
