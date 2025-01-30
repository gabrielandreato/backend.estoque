using AutoMapper;
using backend.person.datalibrary.Dto;
using backend.person.modellibrary.DataModel;

namespace backend.person.datalibrary.Profiles;

public class OrdemCompraLogProfile : Profile
{
    public OrdemCompraLogProfile()
    {
        CreateMap<CreateOrdemCompraLogDto, OrdemCompraLog>();

        CreateMap<UpdateOrdemCompraLogDto, OrdemCompraLog>();
    }
}