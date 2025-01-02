using AutoMapper;
using backend.person.api.Services.Interfaces;
using backend.person.datalibrary.Dto;
using backend.person.datalibrary.Repository;
using backend.person.datalibrary.Repository.Interfaces;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;

namespace backend.person.api.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }
        public Produto Create(CreateProdutoDto produtoDto)
        {
            var produto = _mapper.Map<Produto>(produtoDto);
            return _produtoRepository.Create(produto);
     
        }

        public Produto GetByPk(int id)
        {
            return _produtoRepository.GetByPk(id);
        }

        public Produto Remove(int id)
        {
            return _produtoRepository.Remove(id);
        }


        public Produto Update (int id, UpdateProdutoDto updateProdutoDto)
        {
            return _produtoRepository.Update(id, updateProdutoDto);
        }


        public PagedList<Produto> GetList(string? ids, string? descricao,
        int page, int pageSize)
        {
            var splittedIds = Array.ConvertAll(ids?.Split(",") ?? Array.Empty<string>(), int.Parse);
            return _produtoRepository.GetList(splittedIds, descricao, page, pageSize);
        }
    }
}
