using AutoMapper;
using backend.person.datalibrary.Dto;
using backend.person.modellibrary.DataModel;

namespace backend.person.datalibrary.Profiles;

public class ProdutoCorProfile : Profile
{
   public ProdutoCorProfile()
   {
      CreateMap<CreateProdutoCorDto, ProdutoCor>();
       CreateMap<UpdateProdutoCorDto, ProdutoCor>();
   }
}