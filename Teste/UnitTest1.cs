using DistanciaAmigos.Models;
using DistanciaAmigos.Services.Service;
using System;
using System.Collections.Generic;
using Xunit;

namespace Teste
{
    public class UnitTest1
    {
        [Fact]
        public void CalculaDistanciaCorreto()
        {
            var DistanciaAmigos = new CalculoDistancia();
            IEnumerable<DistanciaEntreAmigos> ListaAmigos;
            DistanciaEntreAmigos Distancia1 = new DistanciaEntreAmigos();
            DistanciaEntreAmigos Distancia2 = new DistanciaEntreAmigos();
            DistanciaEntreAmigos Distancia3 = new DistanciaEntreAmigos();
            DistanciaEntreAmigos Distancia4 = new DistanciaEntreAmigos();

            Amigo Amigo1 = new Amigo();
            Amigo Amigo2 = new Amigo();
            Amigo Amigo3 = new Amigo();
            Amigo Amigo4 = new Amigo();


            Amigo1.Id = 1;
            Amigo1.Nome = "teste1";
            Distancia1.Amigo = Amigo1;
            Distancia1.X = 2;
            Distancia1.Y = 1;
            Amigo2.Id = 1;
            Amigo2.Nome = "teste2";
            Distancia2.Amigo = Amigo2;
            Distancia2.X = 3;
            Distancia2.Y = 1;
            Amigo3.Id = 1;
            Amigo3.Nome = "teste3";
            Distancia3.Amigo = Amigo3;
            Distancia3.X = 1;
            Distancia3.Y = 1;
            Amigo4.Id = 4;
            Amigo4.Nome = "teste4";
            Distancia4.Amigo = Amigo4;
            Distancia4.X = 1;
            Distancia4.Y = 9;

            ListaAmigos = new DistanciaEntreAmigos[] { Distancia1, Distancia2, Distancia3, Distancia4 };

            var Resultado = DistanciaAmigos.CalculaDistancias(2, 1, ListaAmigos);
           


            // var Calculado = new DistanciaResult(){ };
            var PessoaDist = new DistanciaResult() { };
            var pessoa1 = new AmigoCont();
            var pessoa2 = new AmigoCont();
            var pessoa3 = new AmigoCont();
            var Calculado = new List<AmigoCont>();
            pessoa1.Nome = "teste2";
            pessoa1.Id = 0;
            pessoa1.X = 3;
            pessoa1.Y = 1;
            pessoa1.Total = 1;
            Calculado.Add(pessoa1);
            pessoa2.Nome = "teste3";
            pessoa2.Id = 0;
            pessoa2.X = 1;
            pessoa2.Y = 1;
            pessoa2.Total = 1;
            Calculado.Add(pessoa2);
            pessoa3.Nome = "teste4";
            pessoa3.Id = 0;
            pessoa3.X = 1;
            pessoa3.Y = 9;
            pessoa3.Total = 8.06225774829855;
            Calculado.Add(pessoa3);

            Assert.True(Calculado[0].Nome == Resultado.pessoas[0].Nome);
            Assert.True(Calculado[0].X == Resultado.pessoas[0].X);
            Assert.True(Calculado[0].Y == Resultado.pessoas[0].Y);
            Assert.True(Calculado[0].Total == Resultado.pessoas[0].Total);

            Assert.True(Calculado[1].Nome == Resultado.pessoas[1].Nome);
            Assert.True(Calculado[1].X == Resultado.pessoas[1].X);
            Assert.True(Calculado[1].Y == Resultado.pessoas[1].Y);
            Assert.True(Calculado[1].Total == Resultado.pessoas[1].Total);

            Assert.True(Calculado[2].Nome == Resultado.pessoas[2].Nome);
            Assert.True(Calculado[2].X == Resultado.pessoas[2].X);
            Assert.True(Calculado[2].Y == Resultado.pessoas[2].Y);
            Assert.True(Calculado[2].Total == Resultado.pessoas[2].Total);

        }
        [Fact]
        public void DistanciaRepetida()
        {
            var DistanciaAmigos = new CalculoDistancia();
            IEnumerable<DistanciaEntreAmigos> ListaAmigos;
            DistanciaEntreAmigos Distancia1 = new DistanciaEntreAmigos();
            DistanciaEntreAmigos Distancia2 = new DistanciaEntreAmigos();
            DistanciaEntreAmigos Distancia3 = new DistanciaEntreAmigos();
            DistanciaEntreAmigos Distancia4 = new DistanciaEntreAmigos();

            Amigo Amigo1 = new Amigo();
            Amigo Amigo2 = new Amigo();
            Amigo Amigo3 = new Amigo();
            Amigo Amigo4 = new Amigo();


            Amigo1.Id = 1;
            Amigo1.Nome = "teste1";
            Distancia1.Amigo = Amigo1;
            Distancia1.X = 2;
            Distancia1.Y = 1;
            Amigo2.Id = 1;
            Amigo2.Nome = "teste2";
            Distancia2.Amigo = Amigo2;
            Distancia2.X = 3;
            Distancia2.Y = 1;
            Amigo3.Id = 1;
            Amigo3.Nome = "teste3";
            Distancia3.Amigo = Amigo3;
            Distancia3.X = 1;
            Distancia3.Y = 1;
            Amigo4.Id = 4;
            Amigo4.Nome = "teste4";
            Distancia4.Amigo = Amigo4;
            Distancia4.X = 1;
            Distancia4.Y = 1;

            ListaAmigos = new DistanciaEntreAmigos[] { Distancia1, Distancia2, Distancia3, Distancia4 };

            var Resultado = DistanciaAmigos.CalculaDistancias(2, 1, ListaAmigos);
            var Erro = new ErroResposta();
            Erro.Erro = "Erro";
            Erro.Descricao = "Dois amigos não pode ter a mesma localização!";
            var Respostas = new DistanciaResult();
            Respostas.Erro = Erro;

            Assert.Equal(Resultado.Erro.Erro , Respostas.Erro.Erro);
            Assert.Equal(Resultado.Erro.Descricao , Respostas.Erro.Descricao);

        }
        [Fact]
        public void DistanciaNaoCadastrada()
        {
            var DistanciaAmigos = new CalculoDistancia();
            IEnumerable<DistanciaEntreAmigos> ListaAmigos;
            DistanciaEntreAmigos Distancia1 = new DistanciaEntreAmigos();
            DistanciaEntreAmigos Distancia2 = new DistanciaEntreAmigos();
            DistanciaEntreAmigos Distancia3 = new DistanciaEntreAmigos();
            DistanciaEntreAmigos Distancia4 = new DistanciaEntreAmigos();

            Amigo Amigo1 = new Amigo();
            Amigo Amigo2 = new Amigo();
            Amigo Amigo3 = new Amigo();
            Amigo Amigo4 = new Amigo();


            Amigo1.Id = 1;
            Amigo1.Nome = "teste1";
            Distancia1.Amigo = Amigo1;
            Distancia1.X = 2;
            Distancia1.Y = 1;
            Amigo2.Id = 1;
            Amigo2.Nome = "teste2";
            Distancia2.Amigo = Amigo2;
            Distancia2.X = 3;
            Distancia2.Y = 1;
            Amigo3.Id = 1;
            Amigo3.Nome = "teste3";
            Distancia3.Amigo = Amigo3;
            Distancia3.X = 1;
            Distancia3.Y = 1;
            Amigo4.Id = 4;
            Amigo4.Nome = "teste4";
            Distancia4.Amigo = Amigo4;
            Distancia4.X = 1;
            Distancia4.Y = 9;

            ListaAmigos = new DistanciaEntreAmigos[] { Distancia1, Distancia2, Distancia3, Distancia4 };

            var Resultado = DistanciaAmigos.CalculaDistancias(5, 5, ListaAmigos);
            var Erro = new ErroResposta();
            Erro.Erro = "Erro";
            Erro.Descricao = "A localização do amigo solicitada não existe";
            var Respostas = new DistanciaResult();

            Respostas.Erro = Erro;
            Assert.Equal(Resultado.Erro.Erro, Respostas.Erro.Erro);
            Assert.Equal(Resultado.Erro.Descricao, Respostas.Erro.Descricao);

        }
        [Fact]
        public void FaltaValores()
        {
            var DistanciaAmigos = new CalculoDistancia();
            IEnumerable<DistanciaEntreAmigos> ListaAmigos;
            DistanciaEntreAmigos Distancia1 = new DistanciaEntreAmigos();
            DistanciaEntreAmigos Distancia2 = new DistanciaEntreAmigos();
            DistanciaEntreAmigos Distancia3 = new DistanciaEntreAmigos();
            DistanciaEntreAmigos Distancia4 = new DistanciaEntreAmigos();

            Amigo Amigo1 = new Amigo();
            Amigo Amigo2 = new Amigo();
            Amigo Amigo3 = new Amigo();
            Amigo Amigo4 = new Amigo();


            Amigo1.Id = 1;
            Amigo1.Nome = "teste1";
            Distancia1.Amigo = Amigo1;
            Distancia1.X = 2;
            Distancia1.Y = 1;
            Amigo2.Id = 1;
            Amigo2.Nome = "teste2";
            Distancia2.Amigo = Amigo2;
            Distancia2.X = 3;
            Distancia2.Y = 1;
            Amigo3.Id = 1;
            Amigo3.Nome = "teste3";
            Distancia3.Amigo = Amigo3;
            Distancia3.X = 1;
            Distancia3.Y = 1;
       


            ListaAmigos = new DistanciaEntreAmigos[] { Distancia1, Distancia2, Distancia3 };

            var Resultado = DistanciaAmigos.CalculaDistancias(2, 1, ListaAmigos);
            var Erro = new ErroResposta();

            Erro.Erro = "Erro";
            Erro.Descricao = "Existem 3 ou menos amigos cadastrados! , digite a localização dos 1 um amigo alem dos 3" +
                    "cadastrados!";
            var Respostas = new DistanciaResult();

            Respostas.Erro = Erro;

            Respostas.Erro = Erro;
            Assert.Equal(Resultado.Erro.Erro, Respostas.Erro.Erro);
            Assert.Equal(Resultado.Erro.Descricao, Respostas.Erro.Descricao);

        }

        [Fact]
        public void DadoComProblema()
        {
            var DistanciaAmigos = new CalculoDistancia();
            IEnumerable<DistanciaEntreAmigos> ListaAmigos;
            DistanciaEntreAmigos Distancia1 = new DistanciaEntreAmigos();
            DistanciaEntreAmigos Distancia2 = new DistanciaEntreAmigos();
            DistanciaEntreAmigos Distancia3 = new DistanciaEntreAmigos();
            DistanciaEntreAmigos Distancia4 = new DistanciaEntreAmigos();

            Amigo Amigo1 = new Amigo();
            Amigo Amigo2 = new Amigo();
            Amigo Amigo3 = new Amigo();
            Amigo Amigo4 = new Amigo();



            Amigo1.Id = 1;
            Amigo1.Nome = "teste1";
            Distancia1.Amigo = Amigo1;
            Distancia1.X = 2;
            Distancia1.Y = 1;
            Amigo2.Id = 1;
            Amigo2.Nome = "teste2";
            Distancia2.Amigo = Amigo2;
            Distancia2.X = 3;
            Distancia2.Y = 0;
            Amigo3.Id = 1;
            Amigo3.Nome = "teste2";
            Distancia3.Amigo = Amigo3;
            Distancia3.X = 1;
            Distancia3.Y = 1;
            Amigo4.Id = 1;
            Amigo4.Nome = "teste2";
       
            Distancia4.X = 1;
            Distancia4.Y = 31;

            ListaAmigos = new DistanciaEntreAmigos[] { Distancia1, Distancia2, Distancia3, Distancia4 };
            string  q = "a";
            var Resultado = DistanciaAmigos.CalculaDistancias(2, 1, ListaAmigos);
            var Erro = new ErroResposta();


            Erro.Erro = "Erro";
            Erro.Descricao = "Existe uma inconsistencia com os dados!";
            var Respostas = new DistanciaResult();

            Respostas.Erro = Erro;
         
            Assert.Equal(Resultado.Erro.Erro, Respostas.Erro.Erro);
            Assert.Equal(Resultado.Erro.Descricao, Respostas.Erro.Descricao);

        }

    }
}


