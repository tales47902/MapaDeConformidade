using MapaDeConformidade.Data;
using MapaDeConformidade.DTOs;
using MapaDeConformidade.Models;
using Microsoft.EntityFrameworkCore;

namespace MapaDeConformidade.Services
{
    public class EmpresaService
    {
        private readonly DbAppContext _context;

        public EmpresaService(DbAppContext context)
        {
            _context = context;
        }
        public async Task<List<Empresa>> GetEmpresa()
        {
            return await _context.Empresas.ToListAsync();
        }

        public async Task<string> PostEmpresa(CriarEmpresaDTO novaempresa)
        {
            Empresa empresa = new Empresa();

            if (string.IsNullOrWhiteSpace(novaempresa.Nome) || string.IsNullOrWhiteSpace(novaempresa.AtividadeEconomica))
            {
                return "Informe dados corretos, por gentileza";
            }

            empresa.Nome = novaempresa.Nome;
            empresa.AtividadeEconomica = novaempresa.AtividadeEconomica;
            empresa.DataCadastro = DateOnly.FromDateTime(DateTime.Now);

            await _context.Empresas.AddAsync(empresa);
            await _context.SaveChangesAsync();
            return "Empresa salva com sucesso!";
        }

        public async Task<string> PutEmpresa(AtualizarEmpresaDTO novaempresa, int id)
        {
            var empresa = await _context.Empresas.FindAsync(id);

            if (empresa != null)
            {
                if (string.IsNullOrWhiteSpace(novaempresa.Nome) || string.IsNullOrWhiteSpace(novaempresa.AtividadeEconomica))
                {
                    return "Informe dados corretos, por gentileza";
                }

                empresa.Nome = novaempresa.Nome;
                empresa.AtividadeEconomica = novaempresa.AtividadeEconomica;
                await _context.SaveChangesAsync();

                return "Empresa atualizado";
            }

            return "Empresa não encontrado";
        }

        public async Task<string> DeleteEmpresa(int id)
        {
            var empresa = await _context.Empresas.FindAsync(id);

            if (empresa != null)
            {
                _context.Empresas.Remove(empresa);
                await _context.SaveChangesAsync();

                return "Empresa removido com sucesso";
            }
            return "Empresa não encontrada!";
        }
    }
}
