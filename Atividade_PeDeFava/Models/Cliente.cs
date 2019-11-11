using Atividade_PeDeFava.Models.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atividade_PeDeFava.Models
{
    [Table("Vagner_Cliente")]
    public class Cliente : BaseEntity
    {
        [Column("Nome")]
        public string Nome { get; set; }

        [Column("DataNascimento")]
        public DateTime DataNascimento { get; set; }

        [Column("CPF")]
        public string CPF { get; set; }
    }
}
