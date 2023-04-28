
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Vectra.Avaliacao.Backend.Context;
using Vectra.Avaliacao.Backend.Domain;
using Vectra.Avaliacao.Backend.Domain.Contratos;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ProEventos.Persistence
{
   
    public class ContaPersist : IContaPersist
    {
        private readonly  EFContext _context;

        public ContaPersist(EFContext context)
        {
            _context = context;

        }
        public async Task<Conta[]> GetAllContassAsync()
        {
            IQueryable<Conta> query = _context.Contas;
            query = query.AsNoTracking().OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Conta[]> GetAllContasByClienteAsync(string cliente)
        {
            IQueryable<Conta> query = _context.Contas;
            query = query.AsNoTracking().OrderBy(c => c.Id)
                         .Where(c => cliente.ToLower().Contains(cliente.ToLower()));

            return await query.ToArrayAsync();
        }

        

        public async Task<Conta> GetContasByIdAsync(int Id)
        {
            
            IQueryable<Conta> query = _context.Contas;
            query = query.AsNoTracking().OrderBy(c => c.Id)
                .Where(c => c.Id == Id);
            return await query.FirstOrDefaultAsync();
        }
    }
}