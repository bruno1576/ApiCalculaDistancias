using DistanciaAmigos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DistanciaAmigos.Data.Maps
{
    public class DistanciaAmigosMaps : IEntityTypeConfiguration<DistanciaEntreAmigos>
    {
        public void Configure(EntityTypeBuilder<DistanciaEntreAmigos> builder)
        {
            builder.ToTable("DistanciaAmigos");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Amigo.Nome).IsRequired();
            builder.Property(x => x.X).IsRequired();
            builder.Property(x => x.Y).IsRequired();

        }
    }
}
