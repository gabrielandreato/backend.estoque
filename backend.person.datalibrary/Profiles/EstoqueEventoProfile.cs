using AutoMapper;
using backend.person.datalibrary.Dto;
using backend.person.modellibrary.DataModel;

namespace backend.person.datalibrary.Profiles;

public class EstoqueEventoProfile : Profile
{
     public EstoqueEventoProfile()
     {
         CreateMap<CreateEstoqueEventoDto, EstoqueEvento>();
     }
}