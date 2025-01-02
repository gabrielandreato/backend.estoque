using backend.person.datalibrary.Dto;
using backend.person.modellibrary.DataModel;
using backend.person.modellibrary.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.person.datalibrary.Repository.Interfaces;

public interface IProdutoRepository
{
    Produto Create(Produto produto);

    Produto GetByPk(int id);

    Produto Remove(int id);

    Produto Update(int id, UpdateProdutoDto updateProdutoDto);

    PagedList<Produto> GetList(int[]? ids = null, string? desricao = null, 
        int page = 0, int pageSize = 0);
}
