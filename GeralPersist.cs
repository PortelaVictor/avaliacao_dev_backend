
using Vectra.Avaliacao.Backend.Context;
using Vectra.Avaliacao.Backend.Domain.Contratos;

namespace ProEventos.Persistence
{
    public class GeralPersist : IGeralPersist
    {
        private readonly  EFContext _context;

        public GeralPersist(EFContext context)
        {
            _context = context;

        }
        public void Add<T>(T entity) where T : class
        {
            _context.AddAsync(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}