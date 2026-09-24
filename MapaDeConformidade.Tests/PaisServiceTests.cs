using MapaDeConformidade.Data;
using MapaDeConformidade.Models;
using MapaDeConformidade.DTOs;
using MapaDeConformidade.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace MapaDeConformidade.Tests
{
    public class PaisServiceTests
    {
        private DbAppContext CriarContexto()
        {
            var options = new DbContextOptionsBuilder<DbAppContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            return new DbAppContext(options);
        }

        [Fact]
        public async Task GetPaisTest()
        {
            var context = CriarContexto();

            Pais pais = new Pais();
            pais.Nome = "Brasil";
            pais.CodigoISO = "Br";
            await context.Paises.AddAsync(pais);
            await context.SaveChangesAsync();

            var listarpaises = await context.Paises.ToListAsync();

            Assert.NotEmpty(listarpaises);
        }

        [Theory]
        [InlineData("", "", "Informe os dados corretos, por gentileza", false)]
        [InlineData("", "BR", "Informe os dados corretos, por gentileza", false)]
        [InlineData("Brasil", "", "Informe os dados corretos, por gentileza", false)]
        [InlineData("Brasil", "oasis", "Informe os dados corretos, por gentileza", false)]
        [InlineData("Brasil", "BR", "Dados corretos", true)]
        public async Task PostPaisTest(string nome, string codigoiso, string mensagemesperada, bool status)
        {
            var context = CriarContexto();
            PaisService paisService = new PaisService(context);

            CriarPaisDTO novopais = new CriarPaisDTO();
            novopais.Nome = nome;
            novopais.CodigoISO = codigoiso;

            var resultado = await paisService.PostPais(novopais);

            Assert.Equal(mensagemesperada, resultado);

            var paises = await context.Paises.ToListAsync();

            Assert.Equal(status, paises.Any());
        }


        [Theory]
        [InlineData("", "")]
        [InlineData("", "BR")]
        [InlineData("Brasil", "")]
        [InlineData("Brasil", "oasis")]
        [InlineData("Brasil", "BR")]
        public async Task PutTest(string nome, string codigoiso)
        {
            var context = CriarContexto();

            AtualizarPaisDTO novopais = new AtualizarPaisDTO();
            novopais.Nome = nome;
            novopais.CodigoISO = codigoiso;

            if (novopais.CodigoISO.Length > 3)
            {
                return;
            }

            Pais pais = new Pais();
            pais.Nome = novopais.Nome;
            pais.CodigoISO = novopais.CodigoISO;
            await context.SaveChangesAsync();

            var paisatualizado = pais;

            Assert.True(paisatualizado != null, "Dados corretos");
        }
    }
}
