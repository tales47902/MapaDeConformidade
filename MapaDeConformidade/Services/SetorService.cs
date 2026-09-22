using MapaDeConformidade.Data;
using MapaDeConformidade.DTOs;
using MapaDeConformidade.Models;
using Microsoft.EntityFrameworkCore;

namespace MapaDeConformidade.Services
{
    public class SetorService
    {
        private readonly DbAppContext _context;

        public SetorService(DbAppContext context)
        {
            _context = context;
        }
        public async Task<List<Setor>> GetSetor()
        {
            return await _context.Setores.ToListAsync();
        }

        public async Task<string> PostSetor(CriarSetorDTO novosetor)
        {
            Setor setor = new Setor();

            if (string.IsNullOrWhiteSpace(novosetor.Nome))
            {
                return "Informe dados corretos, por gentileza";
            }

            setor.Nome = novosetor.Nome;

            await _context.Setores.AddAsync(setor);
            await _context.SaveChangesAsync();
            return "Setor salvo com sucesso!";
        }

        public async Task<string> PutSetor(AtualizarSetorDTO novosetor, int id)
        {
            var setor = await _context.Setores.FindAsync(id);

            if (setor != null)
            {
                if (string.IsNullOrWhiteSpace(novosetor.Nome))
                {
                    return "Informe dados corretos, por gentileza";
                }

                setor.Nome = novosetor.Nome;
                await _context.SaveChangesAsync();

                return "Setor atualizado";
            }

            return "Setor não encontrado";
        }

        public async Task<string> DeleteSetor(int id)
        {
            var setor = await _context.Setores.FindAsync(id);

            if (setor != null)
            {
                _context.Setores.Remove(setor);
                await _context.SaveChangesAsync();

                return "Setor removido com sucesso";
            }
            return "Setor não encontrado!";
        }
    }
}
