using MapaDeConformidade.Services;
using MapaDeConformidade.DTOs;

namespace MapaDeConformidade.Endpoints
{
    public static class EmpresaEndpoint
    {
        public static void MapEmpresa(WebApplication app)
        {
            app.MapGet("/MapaDeConformidade/Empresas", async (EmpresaService empresa) =>
            {
                var resultado = await empresa.GetEmpresa();
                return Results.Ok(resultado);
            });

            app.MapPost("/MapaDeConformidade/Empresas", async (EmpresaService empresa, CriarEmpresaDTO novaempresa) =>
            {
                var resultado = await empresa.PostEmpresa(novaempresa);
                return Results.Ok(resultado);
            });

            app.MapPut("/MapaDeConformidade/Empresas/{id}", async (EmpresaService empresa, AtualizarEmpresaDTO novaempresa, int id) =>
            {
                var resultado = empresa.PutEmpresa(novaempresa, id);
                return Results.Ok(resultado);
            });

            app.MapDelete("/MapaDeConformidade/Empresas/{id}", async (EmpresaService empresa, int id) =>
            {
                var resultado = await empresa.DeleteEmpresa(id);
                return Results.Ok(resultado);
            });
        }
    }
}
