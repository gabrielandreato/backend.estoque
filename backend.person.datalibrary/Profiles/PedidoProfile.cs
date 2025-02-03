using AutoMapper;
using backend.person.datalibrary.Dto;
using backend.person.modellibrary.DataModel;

namespace backend.person.datalibrary.Profiles;

public class PedidoProfile : Profile
{

    public PedidoProfile()
    {
        CreateMap<CreatePedidoComItensDto, Pedido>();
        CreateMap<UpdatePedidoDto, Pedido>();
        CreateMap<CreatePedidoDto, Pedido>();
    }
}
