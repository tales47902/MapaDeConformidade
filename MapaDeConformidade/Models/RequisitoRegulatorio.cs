namespace MapaDeConformidade.Models
{
    public class RequisitoRegulatorio
    {
        public int Id { get; set; }
        public int PaisId { get; set; }
        public int SetorId { get; set; }
        public int CategoriaId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string FonteNormativa { get; set; }
        public string Obrigatorio { get; set; }

        public Pais pais { get; set; }
        public Setor setor { get; set; }
        public CategoriaRequisito categoria { get; set; }
    }
}
