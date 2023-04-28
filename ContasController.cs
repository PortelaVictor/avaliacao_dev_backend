using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Vectra.Avaliacao.Backend.Application.DTOs;
using Vectra.Avaliacao.Backend.Application.Contratos;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Vectra.Avaliacao.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContasController : ControllerBase
    {
        private readonly IContaService _contaService;
        // Injeção de Dependência
        public ContasController(IContaService contaService)
        {
            _contaService = contaService;
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            try
            {
                var conta = await _contaService.GetAllContasAsync();
                if (conta == null) return NoContent();

                return Ok(conta);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");


            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var conta = await _contaService.GetContasByIdAsync(id);
                if (conta == null) return NoContent();

                return Ok(conta);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar contas. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ContaDto model)
        {
            try
            {
                var conta = await _contaService.SaveContas(model);
                if (conta == null) return NoContent();

                return Ok(conta);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar eventos. Erro: {ex.Message}");
            }
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id)
        {
            try
            {
                var conta = await _contaService.UpdateConta(id);
                if (conta == null) return NoContent();

                return Ok(conta);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar conta. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var conta = await _contaService.GetContasByIdAsync(id);
                if (conta == null) return NoContent();

                return await _contaService.DeleteConta(id) 
                       ? Ok(new { message = "Deletada" }) 
                       : throw new Exception("Ocorreu um problema não específico ao tentar deletar a Conta.");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar contas. Erro: {ex.Message}");
            }
        }

    }
}
