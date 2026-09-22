using MapaDeConformidade.Services;
using MapaDeConformidade.DTOs;

namespace MapaDeConformidade.Endpoints
{
    public static class PaisEndpoint
    {
        public static void MapPaisEndpoints(this WebApplication app)
        {
            app.MapGet("/MapaDeConformidade/Paises", async (PaisService pais) =>
            {
                var resultado = await pais.GetPais();
                return Results.Ok(resultado);
            });

            app.MapPost("/MapaDeConformidade/Paises", async (PaisService pais, CriarPaisDTO novopais) =>
            {
                var resultado = await pais.PostPais(novopais);
                return Results.Ok(resultado);
            });

            app.MapPut("/MapaDeConformidade/Paises/{id}", async (PaisService pais, int id, AtualizarPaisDTO novopais) =>
            {
                var resultado = await pais.PutPais(novopais, id);
                return Results.Ok(resultado);
            });

            app.MapDelete("/MapaDeConformidade/Paises/{id}", (PaisService pais, int id) =>
            {
                var resultado = pais.DeletePais(id);
                return Results.Ok(resultado);
            });
        }
    }
}
