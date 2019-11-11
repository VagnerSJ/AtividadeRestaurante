using Atividade_PeDeFava.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atividade_PeDeFava.Models
{
    [Table("Vagner_Refeicao")]
    public class Refeicao : BaseEntity
    {
        [Column("Id_TipoProduto")]
        public int TipoProdutoId { get; set; }
        public virtual TipoProduto TipoProduto { get; set; }

        [Column("Descricao")]
        public string Descricao { get; set; }

        [Column("Preco")]
        public decimal Preco { get; set; }
    }
}
