using System.Collections.Generic;
using System.Threading.Tasks;
using DistanciaAmigos.Models;
using DistanciaAmigos.Repositories;

namespace DistanciaAmigos.Services.InterfaceServices
{
    public interface IValidaDistancia
    {
        DistanciaResult ValidaDuplicidade(DistanciaEntreAmigos LocalizacaoDoAmigo, LocalizacaoRepository repository);
        DistanciaResult ValidaNome(DistanciaEntreAmigos LocalizacaoDoAmigo);
       
    }
}
