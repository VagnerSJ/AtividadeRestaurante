using Atividade_PeDeFava.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atividade_PeDeFava.Repository.interfaces
{
    public interface IConsumoClienteRepository : IGenericRepository<ConsumoCliente>
    {
        Task<ICollection<ConsumoCliente>> FindByIdCliente(int id);
    }
}
