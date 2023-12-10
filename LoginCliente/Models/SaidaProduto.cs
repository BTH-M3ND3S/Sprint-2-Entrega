using LoginCliente.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginCliente.Models
{
    [Table("SaidaProduto")]
    public class SaidaProduto
    {
        [Column("Id")]
        [Display(Name = "Cód. Saida do Produto")]
        public int Id { get; set; }

        [ForeignKey("ClienteId")]
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        [ForeignKey("ProdutoId")]
        [Display(Name = "Produto")]
        public int ProdutoId { get; set; }
        public Produto? Produto { get; set; }

        [Column("QuantidadeSaidaProduto")]
        [Display(Name = "Quantidade")]
        public int QuantidadeSaidaProduto { get; set; }

        [Column("DataSaidaProduto")]
        [Display(Name = "Data da Saida")]
        public DateTime DataSaidaProduto { get; set; }

        [ForeignKey("UsuarioId")]
        [Display(Name = "Id Do Usuário")]
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        [ForeignKey("TipoSaidaId")]
        [Display(Name = "Id Tipo Saída")]
        public int TipoSaidaId { get; set; }
        public TipoSaida? TipoSaida { get; set; }


    }
}
