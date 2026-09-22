using MapaDeConformidade.Services;
using MapaDeConformidade.DTOs;

namespace MapaDeConformidade.Endpoints
{
    public static class SetorEndpoints
    {
        public static void MapSetorEndpoint(this WebApplication app)
        {
            app.MapGet("/MapaDeConformidade/Setores", async (SetorService setor) =>
            {
                var resultado = await setor.GetSetor();
                return Results.Ok(resultado);
            });

            app.MapPost("/MapaDeConformidade/Setores", async (SetorService setor, CriarSetorDTO novosetor) =>
            {
                var resultado = await setor.PostSetor(novosetor);
                return Results.Ok(resultado);
            });

            app.MapPut("/MapaDeConformidade/Setores/{id}", async (int id, SetorService setor, AtualizarSetorDTO novosetor) =>
            {
                var resultado = await setor.PutSetor(novosetor, id);
                return Results.Ok(resultado);
            });

            app.MapDelete("/MapaDeConformidade/Setores/{id}", async (SetorService setor, int id) => 
            {
                var resultado = await setor.DeleteSetor(id);
                return Results.Ok(resultado);
            });
        }
    }
}
