
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace backend.person.modellibrary.DataModel
{
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int Id { get; set; }

        public string Descricao { get; set; }

        public int IdMarca { get; set; }

        public int IdCategoria { get; set; }
        
        public int IdMaterial { get; set; }
        
    }
}
