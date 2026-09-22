using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("MinhaConexaoBanco");
builder.Services.AddDbContext<DbAppContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

app.MapGet("/MapaDeConformidade/Paises", async (DbAppContext context) =>
{
    return await context.Paises.ToListAsync();
});

app.MapGet("/MapaDeConformidade/Setore", async (DbAppContext context) =>
{
    return await context.Setores.ToListAsync();
});

app.MapGet("/MapaDeConformidade/CategoriasRequisitos", async (DbAppContext context) =>
{
    return await context.CategoriasRequisitos.ToListAsync();
});

app.MapGet("/MapaDeConformidade/Empresas", async (DbAppContext context) =>
{
    return await context.Empresas.ToListAsync();
});

app.MapGet("/MapaDeConformidade/RequisitosRegulatorios", async (DbAppContext context) =>
{
    return await context.RequisitosRegulatorios.ToListAsync();
});

app.MapGet("/MapaDeConformidade/Evidencias", async (DbAppContext context) =>
{
    return await context.Evidencias.ToListAsync();
});

app.MapPost("/MapaDeConformidade/Paises", async (DbAppContext context, Pais novopais) =>
{
    await context.Paises.AddAsync(novopais);
    await context.SaveChangesAsync();
    return Results.Ok("Pais Cadastrado com Sucesso!");
});

app.MapPost("/MapaDeConformidade/Setores", async (DbAppContext context, Setor novosetor) =>
{
    await context.Setores.AddAsync(novosetor);
    await context.SaveChangesAsync();
    return Results.Ok("Setor Cadastrado com Sucesso!");
});

app.MapPost("/MapaDeConformidade/CategoriasRequisitos", async (DbAppContext context, CategoriaRequisito novacategoriarequisitos) =>
{
    await context.CategoriasRequisitos.AddAsync(novacategoriarequisitos);
    await context.SaveChangesAsync();
    return Results.Ok("Categoria de Requisito Cadastrada com Sucesso!");
});

app.MapPost("/MapaDeConformidade/Empresas", async (DbAppContext context, Empresa novaempresa) =>
{
    await context.Empresas.AddAsync(novaempresa);
    await context.SaveChangesAsync();
    return Results.Ok("Empresa Cadastrada com Sucesso!");
});

app.MapPost("/MapaDeConformidade/RequisitosRegulatorios", async (DbAppContext context, RequisitoRegulatorio novorequisitoregulatorio) =>
{
    await context.RequisitosRegulatorios.AddAsync(novorequisitoregulatorio);
    await context.SaveChangesAsync();
    return Results.Ok("Requisito Regulatório Cadastrado com Sucesso!");
});

app.MapPost("/MapaDeConformidade/Evidencias", async (DbAppContext context, Evidencia novaevidencia) =>
{
    await context.Evidencias.AddAsync(novaevidencia);
    await context.SaveChangesAsync();
    return Results.Ok("Evidência Cadastrada com Sucesso!");
});

app.MapPut("/MapaDeConformidade/Paises/{id}", async (DbAppContext context, int id, Pais novopais) =>
{
    var pais = await context.Paises.FindAsync(id);

    if (pais != null)
    {
        pais.Nome = novopais.Nome;
        pais.CodigoISO = novopais.CodigoISO;
        await context.SaveChangesAsync();
        return Results.Ok("País atualizado com sucesso!");
    }
    return Results.NotFound("País não encontrado");
});

app.MapPut("/MapaDeConformidade/Setores/{id}", async (DbAppContext context, int id, Setor novosetor) =>
{
    var setor = await context.Setores.FindAsync(id);

    if (setor != null)
    {
        setor.Nome = novosetor.Nome;
        await context.SaveChangesAsync();
        return Results.Ok("Setor atualizado com sucesso!");
    }
    return Results.NotFound("Setor não encontrado");
});

app.MapPut("/MapaDeConformidade/CategoriasRequisitos/{id}", async (DbAppContext context, int id, CategoriaRequisito novacategoriarequisito) =>
{
    var categoriarequisito = await context.CategoriasRequisitos.FindAsync(id);

    if (categoriarequisito != null)
    {
        categoriarequisito.Nome = novacategoriarequisito.Nome;
        await context.SaveChangesAsync();
        return Results.Ok("País atualizado com sucesso!");
    }
    return Results.NotFound("País não encontrado");
});

app.MapPut("/MapaDeConformidade/Empresas/{id}", async (DbAppContext context, int id, Empresa novaempresa) =>
{
    var empresa = await context.Empresas.FindAsync(id);

    if (empresa != null)
    {
        empresa.Nome = novaempresa.Nome;
        empresa.AtividadeEconomica = novaempresa.AtividadeEconomica;
        empresa.DataCadastro = novaempresa.DataCadastro;
        await context.SaveChangesAsync();
        return Results.Ok("Empresa atualizada com sucesso!");
    }
    return Results.NotFound("Empresa não encontrada");
});

app.MapPut("/MapaDeConformidade/RequisitosRegulatorios/{id}", async (DbAppContext context, int id, RequisitoRegulatorio novorequisitoRegulatorio) =>
{
    var requisitoregulatorio = await context.RequisitosRegulatorios.FindAsync(id);

    if (requisitoregulatorio != null)
    {
        requisitoregulatorio.Titulo = novorequisitoRegulatorio.Titulo;
        requisitoregulatorio.Descricao = novorequisitoRegulatorio.Descricao;
        requisitoregulatorio.FonteNormativa = novorequisitoRegulatorio.FonteNormativa;
        requisitoregulatorio.Obrigatorio = novorequisitoRegulatorio.Obrigatorio;
        await context.SaveChangesAsync();
        return Results.Ok("Requisito Regulatório atualizado com sucesso!");
    }
    return Results.NotFound("Requisito Regulatório não encontrado");
});

app.MapPut("/MapaDeConformidade/Evidencias/{id}", async (DbAppContext context, int id, Evidencia novaevidencia) =>
{
    var evidencia = await context.Evidencias.FindAsync(id);

    if (evidencia != null)
    {
        evidencia.Descricao = novaevidencia.Descricao;
        evidencia.DataRegistro = novaevidencia.DataRegistro;
        evidencia.StatusValidacao = novaevidencia.StatusValidacao;
        await context.SaveChangesAsync();
        return Results.Ok("Evidência atualizado com sucesso!");
    }
    return Results.NotFound("Evidência não encontrada");
});

app.MapDelete("/MapaDeConformidade/Paises/{id}", async (DbAppContext context, int id) =>
{
    var pais = await context.Paises.FindAsync(id);

    if (pais != null)
    {
        context.Paises.Remove(pais);
        await context.SaveChangesAsync();
        return Results.Ok("País removido com sucesso");
    }

    return Results.NotFound("País não encontrado");
});

app.MapDelete("/MapaDeConformidade/Setores/{id}", async (DbAppContext context, int id) =>
{
    var setor = await context.Setores.FindAsync(id);

    if (setor != null)
    {
        context.Setores.Remove(setor);
        await context.SaveChangesAsync();
        return Results.Ok("Setor removido com sucesso");
    }

    return Results.NotFound("Setor não encontrado");
});

app.MapDelete("/MapaDeConformidade/CategoriasRequisitos/{id}", async (DbAppContext context, int id) =>
{
    var categoriarequisito = await context.CategoriasRequisitos.FindAsync(id);

    if (categoriarequisito != null)
    {
        context.CategoriasRequisitos.Remove(categoriarequisito);
        await context.SaveChangesAsync();
        return Results.Ok("Categoria de Requisito removido com sucesso");
    }

    return Results.NotFound("Categoria de Requisito não encontrado");
});

app.MapDelete("/MapaDeConformidade/Empresas/{id}", async (DbAppContext context, int id) =>
{
    var empresa = await context.Empresas.FindAsync(id);

    if (empresa != null)
    {
        context.Empresas.Remove(empresa);
        await context.SaveChangesAsync();
        return Results.Ok("Empresa removida com sucesso");
    }

    return Results.NotFound("Empresa não encontrado");
});

app.MapDelete("/MapaDeConformidade/RequisitosRegulatorios/{id}", async (DbAppContext context, int id) =>
{
    var requisitoregulatorio = await context.RequisitosRegulatorios.FindAsync(id);

    if (requisitoregulatorio != null)
    {
        context.RequisitosRegulatorios.Remove(requisitoregulatorio);
        await context.SaveChangesAsync();
        return Results.Ok("Requisito Regulatório removido com sucesso");
    }

    return Results.NotFound("Requisito Regulatório não encontrado");
});

app.MapDelete("/MapaDeConformidade/Evidencias/{id}", async (DbAppContext context, int id) =>
{
    var evidencia = await context.Evidencias.FindAsync(id);

    if (evidencia != null)
    {
        context.Evidencias.Remove(evidencia);
        await context.SaveChangesAsync();
        return Results.Ok("País removido com sucesso");
    }

    return Results.NotFound("País não encontrado");
});

app.Run();

