using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace LoginCliente.Models
{
    public class TipoSaida
    {
        [Column("Id")]
        [Display(Name = "Cód. Produto")]
        public int Id { get; set; }

        [Column("TipoSaidaDescricao")]
        [Display(Name = "Descrição de Saída")]
        public string TipoSaidaDescricao { get; set; } = string.Empty;
    }
}
