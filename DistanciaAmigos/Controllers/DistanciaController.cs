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
        public JsonResult Get(float X, float Y)
        {
           
            var Consulta = _repository.Get();

            var Calculo = new CalculoDistancia();

            return Json(Calculo.CalculaDistancias(X, Y, Consulta));

        }


        [Authorize(Policy = "UsuarioAPI")]
        [HttpPost]
        public JsonResult Post([FromBody]Amigo LocalizacaoDoAmigo)
        {
          
           var find = _repository.GetFind( LocalizacaoDoAmigo.X, LocalizacaoDoAmigo.Y);
           var contador = find.Count();

            if (contador == 0)
            {
                _repository.Create(LocalizacaoDoAmigo);
                return Json(LocalizacaoDoAmigo);
            }
            else
            {
                Dictionary<string, string> resposta = new Dictionary<string, string>();
                resposta.Add( "Erro", "Não é possivel cadastrar 2 Amigos coma mesma localização");
                return Json(resposta);
            }
           


        }


    }
}
