using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DistanciaAmigos.Models;
using DistanciaAmigos.Repositories;
using DistanciaAmigos.Services.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace DistanciaAmigos.Controllers
{
    [Route("V1/LocalizacaoDoAmigo")]
    public class HomeController : Controller
    {
        private readonly LocalizacaoRepository _repository;
        public HomeController(LocalizacaoRepository repository)

        {
            _repository = repository;

        }


        [Route("{X}/{Y}")]
        [Authorize(Policy = "UsuarioAPI")]
        [HttpGet]
        public ActionResult Get(float X, float Y)
        {


            var Consulta = _repository.Get();

            var Calculo = new CalculoDistancia();
            var resultado = Calculo.CalculaDistancias(X, Y, Consulta);
            if (resultado.Erro == null)
            {
                return StatusCode(200, resultado.pessoas);
            }
            else
            {
                return StatusCode(400, resultado.Erro);
            }
        }


        [Authorize(Policy = "UsuarioAPI")]
        [HttpPost]
        public ActionResult Post([FromBody]DistanciaEntreAmigos LocalizacaoDoAmigo)
        {
            var validacao = new validaCadastro();


            var find = _repository.GetFind(LocalizacaoDoAmigo.X, LocalizacaoDoAmigo.Y);
            var contador = validacao.ValidaDuplicidade(LocalizacaoDoAmigo, _repository);
            var ValidaNome = validacao.ValidaNome(LocalizacaoDoAmigo);
            if (contador.Erro == null)
            {
                if (ValidaNome.Erro == null)
                {
                    _repository.Create(LocalizacaoDoAmigo);
                    return StatusCode(200, LocalizacaoDoAmigo);
                }
                else
                {
                    return StatusCode(400, ValidaNome.Erro);

                }
            }
            else
            {
                return StatusCode(400, contador.Erro);
            }

        }

        


    }
}
