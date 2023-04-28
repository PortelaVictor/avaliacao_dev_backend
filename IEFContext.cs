using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Vectra.Avaliacao.Backend.Domain;

namespace Vectra.Avaliacao.Backend.Application.Interfaces
{
    public interface IEFContext
    {
        DbSet<Conta> Contas { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
