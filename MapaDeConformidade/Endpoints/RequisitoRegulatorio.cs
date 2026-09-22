using MapaDeConformidade.Services;
using MapaDeConformidade.DTOs;

namespace MapaDeConformidade.Endpoints
{
    public static class RequisitoRegulatorio
    {
        public static void MapRequisitoRegulatorio(WebApplication app)
        {
            app.MapGet("/MapaDeConformidade/RequisitosRegulatórios", async (RequisitoRegulatorioService requisitoRegulatorio) =>
            {
                var resultado = await requisitoRegulatorio.GetRequisitoRegulatorio();
                return Results.Ok(resultado);
            });

            app.MapPost("/MapaDeConformidade/RequisitosRegulatórios", async (RequisitoRegulatorioService requisitoRegulatorio, CriarRequisitoRegulatorioDTO novorequisitoregulatorio) =>
            {
                var resultado = await requisitoRegulatorio.PostRequisitoRegulatorio(novorequisitoregulatorio);
                return Results.Ok(resultado);
            });

            app.MapPut("/MapaDeConformidade/RequisitosRegulatórios/{id}", async (RequisitoRegulatorioService requisitoRegulatorio, int id, AtualizarRequisitoRegulatorioDTO novorquisitoregulatorio) =>
            {
                var resultado = await requisitoRegulatorio.PutRequisitoRegulatorio(novorquisitoregulatorio, id);
                return Results.Ok(resultado);
            });

            app.MapDelete("/MapaDeConformidade/RequisitosRegulatórios/{id}", async (RequisitoRegulatorioService requisitoRegulatorio, int id) =>
            {
                var resultado = await requisitoRegulatorio.DeleteRequisitoRegulatorio(id);
                return Results.Ok(resultado);
            });
        }
    }
}
