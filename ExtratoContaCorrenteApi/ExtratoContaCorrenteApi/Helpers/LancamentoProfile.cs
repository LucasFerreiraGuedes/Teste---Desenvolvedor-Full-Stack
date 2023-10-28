using AutoMapper;
using ExtratoContaCorrenteApi.DTO_s;
using ExtratoContaCorrenteApi.Models;

namespace ExtratoContaCorrenteApi.Helpers
{
	public class LancamentoProfile : Profile
	{
        public LancamentoProfile()
        {
            CreateMap<LancamentoDTO,Lancamento>().ReverseMap();

            CreateMap<LancamentoNaoAvulsoDTO, Lancamento>().ReverseMap();

            
        }
    }
}
