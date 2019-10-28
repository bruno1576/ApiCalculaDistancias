using DistanciaAmigos.Models;
using Microsoft.EntityFrameworkCore;
using DistanciaAmigos.Data.Maps;


namespace DistanciaAmigos.Data
{
    public class DistaciaAmigosDataContext : DbContext
    {
        public DbSet<Amigo> Amigo { get; set; }
        // public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlServer(@"Server=localhost,1433;Database=prodcat;User ID=SA;Password=1q2w3e%&!");
            optionsBuilder.UseInMemoryDatabase();

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new DistanciaAmigosMaps());
            // builder.ApplyConfiguration(new CategoryMap());
        }
    }
}
