using DistanciaAmigos.Models;
using Microsoft.EntityFrameworkCore;
using DistanciaAmigos.Data.Maps;


namespace DistanciaAmigos.Data
{
    public class MyContext : DbContext
    {
        public DbSet<Amigo> Amigo { get; set; }
        // public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {    


            
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=DbTeste;User ID=sa;Password=mudar@123");
           
            // optionsBuilder.UseInMemoryDatabase();

        }

        protected override void OnModelCreating(ModelBuilder ModelBuilder)
        {
            
        }
    }
}
