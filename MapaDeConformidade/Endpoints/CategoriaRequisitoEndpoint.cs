using MapaDeConformidade.DTOs;
using MapaDeConformidade.Services;

namespace MapaDeConformidade.Endpoints
{
    public static class CategoriaRequisitoEndpoint
    {
        public static void MapCategoriaRequisito(this WebApplication app)
        {
            app.MapGet("/MapaDeConformidade/CategoriasDeRequisitos", async (CategoriaRequisitoService categoriaRequisito) =>
            {
                var resultado = await categoriaRequisito.GetCategoriaRequisito();
                return Results.Ok(resultado);
            });

            app.MapPost("/MapaDeConformidade/CategoriasDeRequisitos", async (CategoriaRequisitoService categoriaRequisito, CriarCategoriaRequisitoDTO novacategoriarequisito) =>
            {
                var resultado = await categoriaRequisito.PostCategoriaRequisito(novacategoriarequisito);
                return Results.Ok(resultado);
            });

            app.MapPut("/MapaDeConformidade/CategoriaDeRequisitos/{id}", async (CategoriaRequisitoService categoriaRequisito, int id, AtualizarCategoriaRequisitoDTO novacategoriarequisito) =>
            {
                var resultado = await categoriaRequisito.PutCategoriaRequisitos(novacategoriarequisito, id);
                return Results.Ok(resultado);
            });

            app.MapDelete("/MapaDeConformidade/CategoriaDeRequisitos/{id}", async (CategoriaRequisitoService categoriaRequisito, int id) => 
            {
                var resultado = await categoriaRequisito.DeleteCategoriaRequisito(id);
                return Results.Ok(resultado);
            });
        }
    }
}
