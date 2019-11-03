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
        public DistanciaResult CalculaDistancias(float X, float Y, IEnumerable<DistanciaEntreAmigos> Context)
        {
            Dictionary<(double, double), int> Verificador = new Dictionary<(double, double), int>();
            var VerificaDisDupli = new List<AmigoCont> { };
            var SomaDistancia = new List<AmigoCont> { };
            var DistanciasFinais = new List<AmigoCont> { };
            var Erro = new ErroResposta();
            try
            {


                var repetidos = Context
                 .GroupBy(x => x.X, y => y.Y)
                 .Where(g => g.Count() > 1)
                 .Select(g => g.Key)
                 .ToList();

                if (Context.Count() >= 4)
                {
                    AmigoCont Verifica = new AmigoCont();

                    var erro = 0;
                    foreach (var item in Context)
                    {

                        if (VerificaDisDupli.Exists(x => x.X == item.X && x.Y == item.Y) == false)
                        {

                            VerificaDisDupli.Add(new AmigoCont() { Id = item.Id, Nome = item.Amigo.Nome, X = item.X, Y = item.Y });
                        }
                        else
                        {
                            erro = erro + 1;
                        }

                    }

                    if (VerificaDisDupli.Exists(x => x.X == X && x.Y == Y) == true)
                    {
                        if (erro == 0)
                        {
                            var AmigosList = new List<AmigoCont>();


                            Dictionary<int, double> resultado = new Dictionary<int, double>();
                            var result = Context;
                            double soma = 0;
                            float xop = 0;
                            float yop = 0;
                            var i = 0;



                            Dictionary<int, double> pessoas = new Dictionary<int, double>();
                            if (result.Count() >= 3)
                            {
                                foreach (var item in VerificaDisDupli)
                                {

                                    xop = item.X - X;
                                    xop = xop * xop;
                                    yop = item.Y - Y;
                                    yop = yop * yop;
                                    soma = xop + yop;
                                    soma = Math.Sqrt(soma);
                                    if (SomaDistancia.Exists(x => x.X == item.X && x.Y == item.Y) == false)

                                    {
                                        SomaDistancia.Add(new AmigoCont() { Id = item.Id, Nome = item.Nome, X = item.X, Y = item.Y, Total = soma });


                                    }


                                }

                                var ordenado = SomaDistancia.OrderBy(x => x.Total);

                                i = 0;


                                foreach (var itemPessoas in ordenado)
                                {
                                    if (i >= 4)
                                    {
                                        break;
                                    }
                                    if (i != 0) {
                                        DistanciasFinais.Add(itemPessoas);
                                    }
                                    i = i + 1;
                                }


                            }
                            var DistanciResult = new DistanciaResult();
                            DistanciResult.pessoas = DistanciasFinais;
                            DistanciResult.Erro = null;
                            return DistanciResult;
                        }
                        else
                        {

                            
                            Erro.Erro = "Erro";
                            Erro.Descricao = "Dois amigos não pode ter a mesma localização!";
                            var Respostas = new DistanciaResult();

                            Respostas.Erro = Erro;
                            return Respostas;
                        }
                    }
                    else
                    {
                      
                        Erro.Erro = "Erro";
                        Erro.Descricao = "A localização do amigo solicitada não existe";
                        var Respostas = new DistanciaResult();

                        Respostas.Erro = Erro;
                        return Respostas;
                    }

                }
                else
                {
                   
                    Erro.Erro = "Erro";
                    Erro.Descricao = "Existem 3 ou menos amigos cadastrados! , digite a localização dos 1 um amigo alem dos 3" +
                            "cadastrados!";
                    var Respostas = new DistanciaResult();

                    Respostas.Erro = Erro;
                    return Respostas;
                }
            }
            catch (Exception ex)
            {


                
                Erro.Erro = "Erro";
                Erro.Descricao = "Existe uma inconsistencia com os dados!";
                var Respostas = new DistanciaResult();

                Respostas.Erro = Erro;
               return Respostas;
            }
        }
    
    }
}
