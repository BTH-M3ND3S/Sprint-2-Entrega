using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginCliente.Models
{
    [Table("Estado")]
    public class Estado
    {
        [Column("Id")]
        [Display(Name = "Cód. Estado")]
        public int Id { get; set; }

        [Column("EstadoNome")]
        [Display(Name = "Nome Do Estado")]
        public string EstadoNome { get; set; } = string.Empty;

        [ForeignKey("PaisId")]
        [Display(Name = "Cód. País")]
        public int PaisId { get; set; } 
        public Pais? Pais { get; set; }






    }
}
