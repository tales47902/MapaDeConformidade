namespace MapaDeConformidade.DTOs
{
    public class CriarEmpresaDTO
    {
        public string Nome { get; set; }
        public string AtividadeEconomica { get; set; }
        public DateOnly DataCadastro { get; set; }
    }

    public class AtualizarEmpresaDTO
    {
        public string Nome { get; set; }
        public string AtividadeEconomica { get; set; }
        public DateOnly DataCadastro { get; set; }
    }
}
