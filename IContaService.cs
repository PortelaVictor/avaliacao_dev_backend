using System.Threading.Tasks;
using Vectra.Avaliacao.Backend.Application.DTOs;

namespace Vectra.Avaliacao.Backend.Application.Contratos
{
    public interface IContaService
    {
        Task<ContaDto> SaveContas(ContaDto model);
        Task<ContaDto> UpdateConta(int Id);
        Task<bool> DeleteConta(int Id);
        Task<ContaDto> GetAllContasAsync();
        Task<ContaDto> GetContasByIdAsync(int Id);

    }
}