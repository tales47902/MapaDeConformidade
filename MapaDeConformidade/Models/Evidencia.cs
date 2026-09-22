namespace MapaDeConformidade.Models
{
    public class Evidencia
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public int RequisitoId { get; set; }
        public string Descricao { get; set; }
        public DateOnly DataRegistro { get; set; }
        public string StatusValidacao { get; set; }

        public Empresa empresa { get; set; }
        public RequisitoRegulatorio requisito { get; set; }
    }
}
