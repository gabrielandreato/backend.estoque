using AutoMapper;
using backend.person.datalibrary.Dto;
using backend.person.modellibrary.DataModel;

namespace backend.person.datalibrary.Profiles;

public class PedidoStatusProfile : Profile
{
    public PedidoStatusProfile()
    {
        CreateMap<CreatePedidoStatusDto, PedidoStatus>();
        CreateMap<UpdatePedidoStatusDto, PedidoStatus>();
    }
}