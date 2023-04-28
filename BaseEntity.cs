using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vectra.Avaliacao.Backend.Domain
{
    public class BaseEntity<T>
    {
        [Column("ID")]
        [Required]
        public T Id { get; protected set; }
        [Column("UPDATED_AT")]
        [Required]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        [Column("CREATED_AT")]
        [Required]
        public DateTime CreatedAt { get; set; }

        [Column("IS_ACTIVE")]
        [Required]
        public bool IsActive { get; set; }
    }
}
