using System.ComponentModel.DataAnnotations.Schema;

namespace Atividade_PeDeFava.Models.Base
{
    public class BaseEntity
    {
        [Column("Id")]
        public int Id { get; set; }
    }
}
