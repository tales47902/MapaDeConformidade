using MapaDeConformidade.Data;
using MapaDeConformidade.DTOs;
using MapaDeConformidade.Models;
using Microsoft.EntityFrameworkCore;

namespace MapaDeConformidade.Services
{
    public class EvidenciaService
    {
        private readonly DbAppContext _context;

        public EvidenciaService(DbAppContext context)
        {
            _context = context;
        }
        public async Task<List<Evidencia>> GetEvidencia()
        {
            return await _context.Evidencias.ToListAsync();
        }

        public async Task<string> PostEvidencia(CriarEvidenciaDTO novaevidencia)
        {
            Evidencia evidencia = new Evidencia();

            if (string.IsNullOrWhiteSpace(novaevidencia.Descricao) || novaevidencia.StatusValidacao.Equals("Concluído", StringComparison.OrdinalIgnoreCase) || novaevidencia.StatusValidacao.Equals("Pendente", StringComparison.OrdinalIgnoreCase))
            {
                return "Informe dados corretos, por gentileza";
            }

            evidencia.Descricao = novaevidencia.Descricao;
            evidencia.StatusValidacao = novaevidencia.StatusValidacao;
            evidencia.DataRegistro = novaevidencia.DataRegistro;

            await _context.Evidencias.AddAsync(evidencia);
            await _context.SaveChangesAsync();
            return "Evidência salva com sucesso!";
        }

        public async Task<string> PutEvidencia(AtualizarEvidenciaDTO novaevidencia, int id)
        {
            var evidencia = await _context.Evidencias.FindAsync(id);

            if (evidencia != null)
            {
                if (string.IsNullOrWhiteSpace(novaevidencia.Descricao) || novaevidencia.StatusValidacao.Equals("Concluído", StringComparison.OrdinalIgnoreCase) || novaevidencia.StatusValidacao.Equals("Pendente", StringComparison.OrdinalIgnoreCase))
                {
                    return "Informe dados corretos, por gentileza";
                }

                evidencia.Descricao = novaevidencia.Descricao;
                evidencia.StatusValidacao = novaevidencia.StatusValidacao;
                evidencia.DataRegistro = novaevidencia.DataRegistro;
                await _context.SaveChangesAsync();

                return "Evidência atualizada";
            }

            return "Evidência não encontrado";
        }

        public async Task<string> DeleteEvidencia(int id)
        {
            var evidencia = await _context.Evidencias.FindAsync(id);

            if (evidencia != null)
            {
                _context.Evidencias.Remove(evidencia);
                await _context.SaveChangesAsync();

                return "Evidência removida com sucesso";
            }
            return "Evidência não encontrada!";
        }
    }
}
