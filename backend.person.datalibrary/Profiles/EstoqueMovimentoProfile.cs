

using AutoMapper;
using backend.person.datalibrary.Dto;
using backend.person.modellibrary.DataModel;

namespace backend.person.datalibrary.Profiles;

public class EstoqueMovimentoProfile : Profile
{
    public EstoqueMovimentoProfile()
    {
        CreateMap<CreateEstoqueMovimentoDto, EstoqueMovimento>();
    }
}