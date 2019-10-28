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
            var teste = new CalculoDistancia();
            IEnumerable<Amigo> novoteste;
            Amigo Amigo1 = new Amigo();
            Amigo Amigo2 = new Amigo();
            Amigo Amigo3 = new Amigo();
            Amigo Amigo4 = new Amigo();
            Amigo1.Id = 1;
            Amigo1.Nome = "teste";
            Amigo1.X = 2;
            Amigo1.Y = 1;
            Amigo2.Id = 1;
            Amigo2.Nome = "teste2";
            Amigo2.X = 3;
            Amigo2.Y = 1;
            Amigo3.Id = 1;
            Amigo3.Nome = "teste3";
            Amigo3.X = 1;
            Amigo3.Y = 1;
            Amigo4.Id = 4;
            Amigo4.Nome = "teste4";
            Amigo4.X = 1;
            Amigo4.Y = 1;
            novoteste = new Amigo[] { Amigo1, Amigo2, Amigo3, Amigo4 };
            teste.CalculaDistancias(2, 1, novoteste);
            Assert.Equal(teste.CalculaDistancias(2, 1, novoteste), teste.CalculaDistancias(2, 1, novoteste));
           
        }
        [Fact]
        public void CalculaDistanciaErrado()
        {
            var teste = new CalculoDistancia();
            IEnumerable<Amigo> grupo1;
            IEnumerable<Amigo> grupo2;
            Amigo Amigo1 = new Amigo();
            Amigo Amigo2 = new Amigo();
            Amigo Amigo3 = new Amigo();
            Amigo Amigo4 = new Amigo();
            Amigo1.Id = 1;
            Amigo1.Nome = "teste";
            Amigo1.X = 2;
            Amigo1.Y = 1;

            Amigo2.Id = 2;
            Amigo2.Nome = "teste2";
            Amigo2.X = 3;
            Amigo2.Y = 1;

            Amigo3.Id = 3;
            Amigo3.Nome = "teste3";
            Amigo3.X = 40;
            Amigo3.Y = 1;

            Amigo4.Id = 4;
            Amigo4.Nome = "teste4";
            Amigo4.X = 92;
            Amigo4.Y = 1;
            grupo1 = new Amigo[] { Amigo1, Amigo2 ,Amigo4 };
            grupo2 = new Amigo[] { Amigo1, Amigo2, Amigo3};
      
            Assert.Equal(teste.CalculaDistancias(2, 1, grupo1), teste.CalculaDistancias(5, 1, grupo2));

        }
        [Fact]
        public void CalculaDistanciaRepetida()
        {
            var teste = new CalculoDistancia();
            IEnumerable<Amigo> grupo1;
            IEnumerable<Amigo> grupo2;
            Amigo Amigo1 = new Amigo();
            Amigo Amigo2 = new Amigo();
            Amigo Amigo3 = new Amigo();
            Amigo Amigo4 = new Amigo();
            Amigo1.Id = 1;
            Amigo1.Nome = "teste";
            Amigo1.X = 2;
            Amigo1.Y = 1;

            Amigo2.Id = 2;
            Amigo2.Nome = "teste2";
            Amigo2.X = 3;
            Amigo2.Y = 1;

            Amigo3.Id = 3;
            Amigo3.Nome = "teste3";
            Amigo3.X = 40;
            Amigo3.Y = 1;

            Amigo4.Id = 4;
            Amigo4.Nome = "teste4";
            Amigo4.X = 92;
            Amigo4.Y = 1;
            grupo1 = new Amigo[] { Amigo3, Amigo3, Amigo3 };
            grupo2 = new Amigo[] { Amigo3, Amigo3, Amigo3 };
            Dictionary<string, double> resultado = new Dictionary<string, double>();
            resultado.Add("Não podem existir 2 amigos com a mesma localização!", 0);
           

            Assert.Equal(resultado, teste.CalculaDistancias(2,1, grupo2));

        }
        [Fact]
        public void CalculaNomeRepetido()
        {
            var teste = new CalculoDistancia();
            IEnumerable<Amigo> grupo1;
            IEnumerable<Amigo> grupo2;
            Amigo Amigo1 = new Amigo();
            Amigo Amigo2 = new Amigo();
            Amigo Amigo3 = new Amigo();
            Amigo Amigo4 = new Amigo();
            Amigo1.Id = 1;
            Amigo1.Nome = "teste";
            Amigo1.X = 2;
            Amigo1.Y = 1;

            Amigo2.Id = 2;
            Amigo2.Nome = "teste";
            Amigo2.X = 3;
            Amigo2.Y = 1;

            Amigo3.Id = 3;
            Amigo3.Nome = "teste3";
            Amigo3.X = 40;
            Amigo3.Y = 1;

            Amigo4.Id = 4;
            Amigo4.Nome = "teste4";
            Amigo4.X = 92;
            Amigo4.Y = 1;
            grupo1 = new Amigo[] { Amigo1, Amigo2, Amigo3 };
            Dictionary<string, double> ErroNome = new Dictionary<string, double>();
            ErroNome.Add("O mesmo amigo não pode ter 2 localizações!", 0);


            Assert.Equal(ErroNome, teste.CalculaDistancias(2, 1, grupo1));

        }

    }
}
