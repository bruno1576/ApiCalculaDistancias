using DistanciaAmigos.Models;
using Microsoft.EntityFrameworkCore;
using DistanciaAmigos.Data.Maps;
using Microsoft.Extensions.Configuration;

namespace DistanciaAmigos.Data
{
    public class MyContext : DbContext
    {
        public DbSet<Amigo> Amigo { get; set; }
        // public DbSet<Category> Categories { get; set; }
        private readonly IConfiguration configuration;
     //   public MyContext(IConfiguration config)

      //  {
        //    configuration = config;

        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            string testeCon = configuration.GetConnectionString("MyConnStr");

          //  optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=DbNovo;User ID=sa;Password=mudar@123");

          
            // optionsBuilder.UseInMemoryDatabase();

        }


        protected override void OnModelCreating(ModelBuilder ModelBuilder)
        {
            
           
        }
    }
}
