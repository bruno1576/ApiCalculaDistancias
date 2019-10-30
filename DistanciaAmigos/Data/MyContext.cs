using DistanciaAmigos.Models;
using Microsoft.EntityFrameworkCore;
using DistanciaAmigos.Data.Maps;
using Microsoft.Extensions.Configuration;

namespace DistanciaAmigos.Data
{
    public class MyContext : DbContext
    {
        public DbSet<Amigo> Amigo { get; set; }
 
        private readonly IConfiguration configuration;

        public MyContext(IConfiguration config)

       {
            configuration = config;

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            string StringCon = configuration.GetConnectionString("MyConnStr");

              optionsBuilder.UseSqlServer(StringCon);

          
          

        }


        protected override void OnModelCreating(ModelBuilder ModelBuilder)
        {
            
           

        }
    }
}
