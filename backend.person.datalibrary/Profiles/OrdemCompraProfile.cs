using AutoMapper;
using backend.person.datalibrary.Dto;
using backend.person.modellibrary.DataModel;

namespace backend.person.datalibrary.Profiles;

public class OrdemCompraProfile : Profile
{
    public OrdemCompraProfile()
    {
        CreateMap<CreateOrdemCompraDto , OrdemCompra>();
        
        CreateMap<UpdateOrdemCompraDto , OrdemCompra>();

        CreateMap<ReprovarOrdemCompraDto, OrdemCompra>();
    }
    
    
}