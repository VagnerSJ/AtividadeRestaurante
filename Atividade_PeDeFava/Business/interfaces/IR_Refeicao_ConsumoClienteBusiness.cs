using Atividade_PeDeFava.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade_PeDeFava.Business.interfaces
{
    public interface IR_Refeicao_ConsumoClienteBusiness
    {
        Task<R_Refeicao_ConsumoCliente> Create(R_Refeicao_ConsumoCliente r_Refeicao_ConsumoCliente);
        Task<R_Refeicao_ConsumoCliente> Update(R_Refeicao_ConsumoCliente r_Refeicao_ConsumoCliente);
        Task<R_Refeicao_ConsumoCliente> FindById(int id);
        Task<ICollection<R_Refeicao_ConsumoCliente>> FindAll();
        Task Delete(int id);
    }
}
