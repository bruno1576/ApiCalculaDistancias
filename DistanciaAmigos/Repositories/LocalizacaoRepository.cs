using System.Collections.Generic;
using System.Linq;
using DistanciaAmigos.Data;
using DistanciaAmigos.Models;

namespace DistanciaAmigos.Repositories
{
    public class LocalizacaoRepository
    {

        private readonly MyContext _Context;
        public LocalizacaoRepository(MyContext Context)
        {
           
            _Context = Context;
        }
        public IEnumerable<Amigo> Get()
        {
        

            return _Context.Amigo;

        }
        public IQueryable <Amigo> GetFind(float X , float Y)
        {
            return _Context.Amigo.Where(c => c.X == X && c.Y == Y);

            //return _Context.Amigo.Find();

        }
        public void Create(Amigo localizacao)
        {
            _Context.Amigo.Add(localizacao);
            _Context.SaveChanges();
        }
    }
}
