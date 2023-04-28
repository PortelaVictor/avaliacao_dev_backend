using Vectra.Avaliacao.Backend.Domain;

namespace Vectra.Avaliacao.Backend.Domain.Contratos
{
    public interface IContaPersist
    {
        //Contas
        
        Task<Conta[]> GetAllContasByClienteAsync(string cliente); 
        Task<Conta[]> GetAllContassAsync(); 
        Task<Conta> GetContasByIdAsync(int Id);

    }
}