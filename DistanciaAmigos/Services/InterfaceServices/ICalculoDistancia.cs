using System.Collections.Generic;
using System.Threading.Tasks;
using DistanciaAmigos.Models;

namespace DistanciaAmigos.Services.InterfaceServices
{
    public interface ICalculoDistancia
    {
        DistanciaResult CalculaDistancias(float X, float Y, IEnumerable<DistanciaEntreAmigos> Context);
    }
}
