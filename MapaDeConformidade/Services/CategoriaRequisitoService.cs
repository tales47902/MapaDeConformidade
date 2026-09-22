using MapaDeConformidade.Data;
using MapaDeConformidade.DTOs;
using MapaDeConformidade.Models;
using Microsoft.EntityFrameworkCore;

namespace MapaDeConformidade.Services
{
    public class CategoriaRequisitoService
    {
        private readonly DbAppContext _context;

        public CategoriaRequisitoService(DbAppContext context)
        {
            _context = context;
        }
        public async Task<List<CategoriaRequisito>> GetCategoriaRequisito()
        {
            return await _context.CategoriasRequisitos.ToListAsync();
        }

        public async Task<string> PostCategoriaRequisito(CriarCategoriaRequisitoDTO novacategoriarequisito)
        {
            CategoriaRequisito categoriarequisito = new CategoriaRequisito();

            if (string.IsNullOrWhiteSpace(novacategoriarequisito.Nome))
            {
                return "Informe dados corretos, por gentileza";
            }

            categoriarequisito.Nome = novacategoriarequisito.Nome;

            await _context.CategoriasRequisitos.AddAsync(categoriarequisito);
            await _context.SaveChangesAsync();
            return "Categoria de Requisito salva com sucesso!";
        }

        public async Task<string> PutCategoriaRequisitos(AtualizarCategoriaRequisitoDTO novacategoriarequisito, int id)
        {
            var categoriarequisito = await _context.CategoriasRequisitos.FindAsync(id);

            if (categoriarequisito != null)
            {
                if (string.IsNullOrWhiteSpace(categoriarequisito.Nome))
                {
                    return "Informe dados corretos, por gentileza";
                }

                categoriarequisito.Nome = novacategoriarequisito.Nome;
                await _context.SaveChangesAsync();

                return "Categoria de Requisito atualizada";
            }

            return "Categoria de Requisito não encontrado";
        }

        public async Task<string> DeleteCategoriaRequisito(int id)
        {
            var categoriarequisito = await _context.CategoriasRequisitos.FindAsync(id);

            if (categoriarequisito != null)
            {
                _context.CategoriasRequisitos.Remove(categoriarequisito);
                await _context.SaveChangesAsync();

                return "Categoria de Requisito removida com sucesso";
            }
            return "Categoria de Requisito não encontrada!";
        }
    }
}
