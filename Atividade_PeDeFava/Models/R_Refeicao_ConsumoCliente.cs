using Atividade_PeDeFava.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atividade_PeDeFava.Models
{
    [Table("Vagner_R_Refeicao_ConsumoCliente")]
    public class R_Refeicao_ConsumoCliente : BaseEntity
    {
        [Column("Id_Refeicao")]
        public int RefeicaoId { get; set; }
        public virtual Refeicao Refeicao { get; set; }

        [Column("Id_ConsumoCliente")]
        public int ConsumoClienteId { get; set; }
        public virtual ConsumoCliente ConsumoCliente { get; set; }

        
    }
}
