using DistanciaAmigos.Data.Maps;
using DistanciaAmigos.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DistanciaAmigos.Data
{
    public class MyContextIdentity : IdentityDbContext
    {
        public DbSet<Amigo> LocalizacaoDoAmigo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=Teste98;User ID=sa;Password=mudar@123");

        }

      

    }
}
