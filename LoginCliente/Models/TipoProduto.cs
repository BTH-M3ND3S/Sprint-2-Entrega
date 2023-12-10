using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace LoginCliente.Models
{
    [Table("TipoProduto")]
    public class TipoProduto
    {
        [Column("Id")]
        [Display(Name = "Código do Usuário")]
        public int Id { get; set; }

        [Column("TipoProdutoDescricao")]
        [Display(Name =  "Descrição do Produto")]
        public string TipoProdutoDescricao { get; set; } = string.Empty;
    }
}
