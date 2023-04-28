using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vectra.Avaliacao.Backend.Domain
{
    [Table("Conta")]
    public class Conta : BaseEntity<int>
    {
        [Column("Agencia")]
        [Required]
        public string Agencia { get; set; }
        [Column("Numero")]
        [Required]
        public string Numero { get; set; }
        [Column("Cliente")]
        [Required]
        public string Cliente { get; set; }
        [Column("Saldo")]
        [Required]
        public double Saldo { get; set; }
    }
}
