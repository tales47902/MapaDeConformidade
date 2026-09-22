namespace MapaDeConformidade.DTOs
{
    public class CriarRequisitoRegulatorioDTO
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string FonteNormativa { get; set; }
        public string Obrigatorio { get; set; }
    }

    public class AtualizarRequisitoRegulatorioDTO
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string FonteNormativa { get; set; }
        public string Obrigatorio { get; set; }
    }
}
