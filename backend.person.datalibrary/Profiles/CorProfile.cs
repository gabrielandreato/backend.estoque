using AutoMapper;
using backend.person.datalibrary.Dto;
using backend.person.modellibrary.DataModel;

namespace backend.person.datalibrary.Profiles;

public class CorProfile : Profile
{
    public CorProfile()
    {
        CreateMap<CreateCorDto, Cor>();
        
        CreateMap<UpdateCorDto, Cor>();
    }
}