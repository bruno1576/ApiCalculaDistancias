using System.Collections.Generic;
using System.Linq;
using DistanciaAmigos.Data;
using DistanciaAmigos.Models;
using Microsoft.EntityFrameworkCore;

namespace DistanciaAmigos.Repositories
{
    public class LocalizacaoRepository
    {

        private readonly MyContext _Context;
        public LocalizacaoRepository(MyContext Context)
        {
           
            _Context = Context;
        }
        public IEnumerable<DistanciaEntreAmigos> Get()
        {
           var DistanciaAmigos = _Context.DistanciaAmigos
                .Include(amigo => amigo.Amigo)
                .ToList();

            return DistanciaAmigos;

        }
        public IQueryable <DistanciaEntreAmigos> GetFind(float X , float Y)
        {
            return _Context.DistanciaAmigos.Where(c => c.X == X && c.Y == Y);


        }
        public void Create(DistanciaEntreAmigos localizacao)
        {
            _Context.DistanciaAmigos.Add(localizacao);
            _Context.SaveChanges();
        }
    }
}
