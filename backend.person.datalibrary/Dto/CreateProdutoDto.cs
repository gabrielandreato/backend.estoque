
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace backend.person.datalibrary.Dto
{
    public class CreateProdutoDto
    {
        public string Descricao { get; set; }

        public int IdMarca { get; set; }
    }
}
