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

            CreateMap<LancamentoNaoAvulsoDTO, Lancamento>()
                .ForMember(x => x.avulso, opt => opt.MapFrom(x => Avulso.NãoAvulso))
                .ForMember(x => x.status, opt => opt.MapFrom(x => Status.Válido));



		}
    }
}
