using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginCliente.Models
{
    [Table("Pais")]
    public class Pais
    {
        [Column("Id")]
        [Display(Name = "Cód. Pais")]
        public int Id { get; set; }

        [Column("PaisNome")]
        [Display(Name = "Nome Do País")]
        public string PaisNome { get; set; } = string.Empty;
    }
}
