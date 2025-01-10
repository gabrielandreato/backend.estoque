using AutoMapper;
using backend.person.datalibrary.Dto;
using backend.person.modellibrary.DataModel;

namespace backend.person.datalibrary.Profiles;

public class MarcaProfile : Profile
{
    public MarcaProfile()
    {
        CreateMap<CreateMarcaDto, Marca>();
        
        CreateMap<UpdateMarcaDto, Marca>();
    }
}