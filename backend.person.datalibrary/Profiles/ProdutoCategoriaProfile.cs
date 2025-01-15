using AutoMapper;
using backend.person.datalibrary.Dto;
using backend.person.modellibrary.DataModel;

namespace backend.person.datalibrary.Profiles;

public class ProdutoCategoriaProfile : Profile
{
    public ProdutoCategoriaProfile()
    {
        CreateMap<CreateProdutoCategoriaDto, ProdutoCategoria>();
        CreateMap<UpdateProdutoCategoriaDto, ProdutoCategoria>();
    }
}