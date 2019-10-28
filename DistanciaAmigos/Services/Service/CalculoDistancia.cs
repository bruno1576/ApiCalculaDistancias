using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DistanciaAmigos.Data;
using DistanciaAmigos.Models;
using DistanciaAmigos.Repositories;

namespace DistanciaAmigos.Services.Service
{
    public class CalculoDistancia : InterfaceServices.ICalculoDistancia
    {
        public Dictionary<string, double> CalculaDistancias(float X, float Y, IEnumerable<Amigo> Context)
        {

            var repetidos = Context
                 .GroupBy(x => x.X , y => y.Y)
                 .Where(g => g.Count() > 1)
                 .Select(g => g.Key)
                 .ToList();
            Dictionary<(double, double), string> Verificador = new Dictionary<(double, double), string>();
            var erro = 0;
            foreach (var item in Context)
            {


                if (Verificador.ContainsKey((item.X, item.Y)) == false)
                {
                    Verificador.Add((item.X, item.Y), item.Nome);
                }
                else
                {
                    erro = erro + 1;
                }

            }

            if (erro == 0)
            {
                Dictionary<string, double> resultado = new Dictionary<string, double>();
                var result = Context;
                // return Ok(await _services.GetAll());
                double somar = 0;
                float xop = 0;
                float yop = 0;
                var i = 0;
               
                

                Dictionary<string, double> pessoas = new Dictionary<string, double>();
                if (result.Count() >= 3)
                {
                    foreach (var item in result)
                    {

                        xop = item.X - X;
                        xop = xop * xop;
                        yop = item.Y - Y;
                        yop = yop * yop;
                        somar = xop + yop;
                        somar = Math.Sqrt(somar);
                        if (pessoas.ContainsKey(item.Nome) == false)
                        {
                            pessoas.Add(item.Nome, somar);
                        }
                        else
                        {
                            Dictionary<string, double> ErroNome = new Dictionary<string, double>();
                            ErroNome.Add("O mesmo amigo não pode ter 2 localizações!", 0);
                            return ErroNome;

                        }

                    }

                    var ordered = pessoas.OrderBy(x => x.Value);

                    i = 0;


                    foreach (var itemPessoas in ordered)
                    {
                        if (i >= 3)
                        {
                            break;
                        }

                        resultado.Add(itemPessoas.Key, itemPessoas.Value);

                        i = i + 1;
                    }

                    return resultado;
                }
                return resultado;
            }   
            else
            {
                Dictionary<string, double> resultado = new Dictionary<string, double>();
                resultado.Add("Não podem existir 2 amigos com a mesma localização!",0);
                return resultado;
            }

        }
    }
}
