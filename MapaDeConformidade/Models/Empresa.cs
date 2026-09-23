namespace MapaDeConformidade.Models
{
    public class Empresa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int PaisId { get; set; }
        public int SetorId { get; set; }
        public string AtividadeEconomica { get; set; }
        public DateOnly DataCadastro { get; set; }

        public Pais pais { get; set; }
        public Setor setor { get; set; }
    }
}
