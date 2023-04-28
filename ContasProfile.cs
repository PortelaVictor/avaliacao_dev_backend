using AutoMapper;
using Vectra.Avaliacao.Backend.Application.DTOs;
using Vectra.Avaliacao.Backend.Domain;

namespace ProEventos.API.Helpers
{
    public class ContasProfile : Profile 
    {
        public ContasProfile()
        {
            CreateMap<Conta, ContaDto>().ReverseMap();
        }
    }
}