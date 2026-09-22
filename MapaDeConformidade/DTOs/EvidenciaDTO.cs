namespace MapaDeConformidade.DTOs
{
    public class CriarEvidenciaDTO
    {
        public string Descricao { get; set; }
        public DateOnly DataRegistro { get; set; }
        public string StatusValidacao { get; set; }
    }

    public class AtualizarEvidenciaDTO
    {
        public string Descricao { get; set; }
        public DateOnly DataRegistro { get; set; }
        public string StatusValidacao { get; set; }
    }
}
