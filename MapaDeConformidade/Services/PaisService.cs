using MapaDeConformidade.Data;
using MapaDeConformidade.DTOs;
using MapaDeConformidade.Models;
using Microsoft.EntityFrameworkCore;

namespace MapaDeConformidade.Services
{
    public class PaisService
    {
        private readonly DbAppContext _context;

        public PaisService(DbAppContext context)
        {
            _context = context;
        }
        public async Task<List<Pais>> GetPais()
        {
            return await _context.Paises.ToListAsync();
        }

        public async Task<string> PostPais(CriarPaisDTO novopais)
        {
            Pais pais = new Pais();

            if (string.IsNullOrWhiteSpace(novopais.Nome) || string.IsNullOrWhiteSpace(novopais.CodigoISO))
            {
                return "Informe dados corretos, por gentileza";
            }

            pais.Nome = novopais.Nome;
            pais.CodigoISO = novopais.CodigoISO;

            await _context.Paises.AddAsync(pais);
            await _context.SaveChangesAsync();
            return "Contato salvo com sucesso!";
        }

        public async Task<string> PutPais(AtualizarPaisDTO novopais, int id)
        {
            var pais = await _context.Paises.FindAsync(id);

            if (pais != null)
            {
                if (string.IsNullOrWhiteSpace(novopais.Nome) || string.IsNullOrWhiteSpace(novopais.CodigoISO))
                {
                    return "Informe dados corretos, por gentileza";
                }

                pais.Nome = novopais.Nome;
                pais.CodigoISO = novopais.CodigoISO;
                await _context.SaveChangesAsync();

                return "Pais atualizado";
            }

            return "Pais não encontrado";
        }

        public async Task<string> DeletePais(int id)
        {
            var pais = await _context.Paises.FindAsync(id);

            if (pais != null)
            {
                _context.Paises.Remove(pais);
                await _context.SaveChangesAsync();

                return "País removido com sucesso";
            }
            return "País não encontrado!";
        }
    }
}
