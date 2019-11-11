using Atividade_PeDeFava.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atividade_PeDeFava.Models
{
    [Table("Vagner_TipoProduto")]
    public class TipoProduto : BaseEntity
    {
        [Column("Descricao")]
        public string Descricao { get; set; }
    }
}
