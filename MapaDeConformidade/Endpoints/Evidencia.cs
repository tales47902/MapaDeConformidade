using MapaDeConformidade.Services;
using MapaDeConformidade.DTOs;

namespace MapaDeConformidade.Endpoints
{
    public static class Evidencia
    {
        public static void MapEvidencia(WebApplication app)
        {
            app.MapGet("/MapaDeConformidade/Evidências", async (EvidenciaService evidencia) =>
            {
                var resultado = await evidencia.GetEvidencia();
                return Results.Ok(resultado);
            });

            app.MapPost("/MapaDeConformidade/Evidências", async (EvidenciaService evidencia, CriarEvidenciaDTO novaevidencia) =>
            {
                var resultado = await evidencia.PostEvidencia(novaevidencia);
                return Results.Ok(resultado);
            });

            app.MapPut("/MapaDeConformidade/Evidências/{id}", async (EvidenciaService evidencia, AtualizarEvidenciaDTO novaevidencia, int id) =>
            {
                var resultado = await evidencia.PutEvidencia(novaevidencia, id);
                return Results.Ok(resultado);
            });

            app.MapDelete("/MapaDeConformidade/Evidências/{id}", async (EvidenciaService evidencia, int id) =>
            {
                var resultado = evidencia.DeleteEvidencia(id);
                return Results.Ok(resultado);
            });
        }
    }
}
