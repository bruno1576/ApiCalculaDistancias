using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApi_JWT.Models;
using WebApi_JWT.ProviderJWT;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi_JWT.Controllers
{
    public class TokenController : Controller
    {

        [Route("api/CreateToken")]
        [AllowAnonymous]
        [HttpPost]
        [Produces("application/json")]
        public IActionResult CreateToken([FromBody] Usuario user)
        {
        


            var token = new TokenJWTBuilder()
                .AddSecurityKey(ProviderJWT.JWTSecurityKey.Create("Secret_Key-12345678"))
                .AddSubject("Valdir Ferreira")
                .AddIssuer("Teste.Securiry.Bearer")
                .AddAudience("Teste.Securiry.Bearer")
                .AddClaim("UsuarioAPINumero", "1")
                .AddExpiry(999999999)
                .Builder();

            return Ok(token.value);
        }
        [Authorize(Policy = "UsuarioAPI")]
        [Route("api/CreateToken")]
        [HttpGet]
        public string CreateToken()
        {
            //_repository.Create(LocalizacaoDoAmigo); [FromBody]LocalizacaoDoAmigo LocalizacaoDoAmigo
            return "Teste Post";
        }


    }
}
