using DistanciaAmigos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DistanciaAmigos.Data.Maps
{
    public class DistanciaAmigosMaps : IEntityTypeConfiguration<Amigo>
    {
        public void Configure(EntityTypeBuilder<Amigo> builder)
        {
            builder.ToTable("Amigo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.X).IsRequired();
            builder.Property(x => x.Y).IsRequired();

        }
    }
}
