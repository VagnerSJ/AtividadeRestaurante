using Atividade_PeDeFava.Models.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atividade_PeDeFava.Models
{
    [Table("Vagner_ConsumoCliente")]
    public class ConsumoCliente : BaseEntity
    {
        [Column("Id_Cliente")]
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

        [Column("Mesa")]
        public int Mesa { get; set; }

        [Column("Data")]
        public DateTime Data { get; set; }
    }
}
