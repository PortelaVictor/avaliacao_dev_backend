using AutoMapper;
using Microsoft.Extensions.Logging;
using ProEventos.Persistence;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Vectra.Avaliacao.Backend.Application.Contratos;
using Vectra.Avaliacao.Backend.Application.DTOs;
using Vectra.Avaliacao.Backend.Domain;
using Vectra.Avaliacao.Backend.Domain.Contratos;

namespace Vectra.Avaliacao.Backend.Application
{
    public class ContaService : IContaService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IContaPersist _contaPersist;
        private readonly IMapper _mapper;

        public ContaService(IGeralPersist geralPersist,
                            IContaPersist contaPersist, 
                            IMapper mapper) 
        {
            _geralPersist = geralPersist;
            _contaPersist = contaPersist;
            _mapper = mapper;
        }
        public async Task<ContaDto> SaveContas(ContaDto model)
        {
            try
            {
                var conta = _mapper.Map<Conta>(model);
                _geralPersist.Add<Conta>(conta);
                if (await _geralPersist.SaveChangesAsync())
                {
                    var contaRetorno = await _contaPersist.GetContasByIdAsync(conta.Id);

                    return _mapper.Map<ContaDto>(contaRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ContaDto> UpdateConta(int Id)
        {
            try
            {
                var conta = await _contaPersist.GetContasByIdAsync(Id);
                if (conta == null) return null;

                Id = conta.Id;

               
                _geralPersist.Update<Conta>(conta);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var contaRetorno = await _contaPersist.GetContasByIdAsync(Id);

                    return _mapper.Map<ContaDto>(contaRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<bool> DeleteConta(int Id)
        {
            try
            {
                var conta = await _contaPersist.GetContasByIdAsync(Id);
                if (conta == null) throw new Exception("Evento para delete não encontrado.");

                _geralPersist.Delete<Conta>(conta);
                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ContaDto> GetAllContasAsync()
        {
            try
            {
                var contas = await _contaPersist.GetAllContassAsync();
                if (contas == null) return null;

                var resultado = _mapper.Map<ContaDto>(contas);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ContaDto> GetContasByIdAsync(int Id)
        {
            try
            {
                var contas = await _contaPersist.GetAllContassAsync();
                if (contas == null) return null;

                var resultado = _mapper.Map<ContaDto>(contas);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


       
    }
}