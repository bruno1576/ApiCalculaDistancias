using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DistanciaAmigos.Data;
using DistanciaAmigos.Models;
using DistanciaAmigos.Repositories;

namespace DistanciaAmigos.Services.Service
{
    public class validaCadastro : InterfaceServices.IValidaDistancia
    {

        public DistanciaResult ValidaDuplicidade(DistanciaEntreAmigos LocalizacaoDoAmigo, LocalizacaoRepository repository)
        {

            var find = repository.GetFind(LocalizacaoDoAmigo.X, LocalizacaoDoAmigo.Y);
            var contador = find.Count();
            var Respostas = new DistanciaResult();
            if (contador > 0)
            {
                var Erro = new ErroResposta();
                Erro.Erro = "Erro";
                Erro.Descricao = "Dois amigos não podem ter a mesma localização!";
               

                Respostas.Erro = Erro;
                return Respostas;

            }
            else
            {
                Respostas.Erro = null;
                return Respostas;

            }
         
        }

        public DistanciaResult ValidaNome(DistanciaEntreAmigos LocalizacaoDoAmigo)
        {
            var Respostas = new DistanciaResult();
            if (LocalizacaoDoAmigo.Amigo.Nome == "")
            {
                var Erro = new ErroResposta();
                Erro.Erro = "Erro";
                Erro.Descricao = "Nome em branco!";


                Respostas.Erro = Erro;
                return Respostas;

            }
            else
            {
                Respostas.Erro = null;
                return Respostas;

            }
        }
    }
}
