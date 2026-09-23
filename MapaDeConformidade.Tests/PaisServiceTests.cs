using MapaDeConformidade.Data;
using MapaDeConformidade.Models;
using MapaDeConformidade.DTOs;
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

        [Theory]
        [InlineData("", "")]
        [InlineData("Brasil", "oasis")]
        [InlineData("Brasil", "BR")]
        public async Task PostPaisTest(string nome, string codigoiso)
        {
            var context = CriarContexto();
            CriarPaisDTO novopais = new CriarPaisDTO();
            novopais.Nome = nome;
            novopais.CodigoISO = codigoiso;

            if(string.IsNullOrWhiteSpace(novopais.Nome) || string.IsNullOrWhiteSpace(novopais.CodigoISO) || novopais.CodigoISO.Length > 3)
            {
                return;
            }

            else
            {
                Pais pais = new Pais();
                pais.Nome = novopais.Nome;
                pais.CodigoISO = novopais.CodigoISO;

                await context.Paises.AddAsync(pais);
                await context.SaveChangesAsync();
                Assert.True(pais.Id > 0, "Dados corretos");
            }
        }
    }
}
