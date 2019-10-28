using System.Collections.Generic;
using System.Threading.Tasks;
using DistanciaAmigos.Models;

namespace DistanciaAmigos.Services.InterfaceServices
{
    public interface ICalculoDistancia
    {
        Dictionary<string, double> CalculaDistancias(float X, float Y, IEnumerable<Amigo> Context);
    }
}
