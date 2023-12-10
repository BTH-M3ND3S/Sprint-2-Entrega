using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginCliente.Models
{
    [Table("EntradaProduto")]
    public class EntradaProduto
    {
        [Column("Id")]
        [Display(Name = "Cód. Entrada Produto")]
        public int Id { get; set; }

        [ForeignKey("ProdutoId")]
        [Display(Name = "Produto")]
        public int ProdutoId { get; set; }
        public Produto? Produto { get; set; }

        [Column("EntradaProdutoEstoque")]
        [Display(Name = "Quantidade em estoque")]
        public int EntradaProdutoEstoque { get; set; }
        

        [Column("DataEntrada")]
        [Display(Name = "Data Entrada")]
        public DateTime DataEntrada { get; set; }
    }
}
