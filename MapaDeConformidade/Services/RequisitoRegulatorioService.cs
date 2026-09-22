using MapaDeConformidade.Data;
using MapaDeConformidade.DTOs;
using MapaDeConformidade.Models;
using Microsoft.EntityFrameworkCore;

namespace MapaDeConformidade.Services
{
    public class RequisitoRegulatorioService
    {
        private readonly DbAppContext _context;

        public RequisitoRegulatorioService(DbAppContext context)
        {
            _context = context;
        }
        public async Task<List<RequisitoRegulatorio>> GetRequisitoRegulatorio()
        {
            return await _context.RequisitosRegulatorios.ToListAsync();
        }

        public async Task<string> PostRequisitoRegulatorio(CriarRequisitoRegulatorioDTO novorequisitoregulatorio)
        {
            RequisitoRegulatorio requisitoregulatorio = new RequisitoRegulatorio();

            if (string.IsNullOrWhiteSpace(novorequisitoregulatorio.Titulo) || string.IsNullOrWhiteSpace(novorequisitoregulatorio.Descricao) || (novorequisitoregulatorio.Obrigatorio.Equals("sim", StringComparison.OrdinalIgnoreCase) || novorequisitoregulatorio.Obrigatorio.Equals("não", StringComparison.OrdinalIgnoreCase)
            {
                return "Informe dados corretos, por gentileza";
            }

            requisitoregulatorio.Titulo = novorequisitoregulatorio.Titulo;
            requisitoregulatorio.Descricao = novorequisitoregulatorio.Descricao;
            requisitoregulatorio.Obrigatorio = novorequisitoregulatorio.Obrigatorio;
            await _context.RequisitosRegulatorios.AddAsync(requisitoregulatorio);
            await _context.SaveChangesAsync();
            return "Requisito regulatório salvo com sucesso!";
        }

        public async Task<string> PutRequisitoRegulatorio(AtualizarRequisitoRegulatorioDTO novorequisitoregulatorio, int id)
        {
            var requisitoregulatorio = await _context.RequisitosRegulatorios.FindAsync(id);

            if (requisitoregulatorio != null)
            {
                if (string.IsNullOrWhiteSpace(novorequisitoregulatorio.Titulo) || string.IsNullOrWhiteSpace(novorequisitoregulatorio.Descricao) || (novorequisitoregulatorio.Obrigatorio.Equals("sim", StringComparison.OrdinalIgnoreCase) || novorequisitoregulatorio.Obrigatorio.Equals("não", StringComparison.OrdinalIgnoreCase)
                {
                    return "Informe dados corretos, por gentileza";
                }

                requisitoregulatorio.Titulo = novorequisitoregulatorio.Titulo;
                requisitoregulatorio.Descricao = novorequisitoregulatorio.Descricao;
                requisitoregulatorio.Obrigatorio = novorequisitoregulatorio.Obrigatorio;
                await _context.SaveChangesAsync();

                return "Requisito regulatório atualizado";
            }

            return "Requisito regulatório não encontrado";
        }

        public async Task<string> DeleteRequisitoRegulatorio(int id)
        {
            var requisitoregulatorio = await _context.RequisitosRegulatorios.FindAsync(id);

            if (requisitoregulatorio != null)
            {
                _context.RequisitosRegulatorios.Remove(requisitoregulatorio);
                await _context.SaveChangesAsync();

                return "Requisito Regulatório removido com sucesso";
            }
            return "Requisito Regulatório não encontrado!";
        }
    }
}
