using Atividade_PeDeFava.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atividade_PeDeFava.Business.interfaces
{
    public interface IConsumoClienteBusiness
    {
        Task<ConsumoCliente> Create(ConsumoCliente consumoCliente);
        Task<ConsumoCliente> Update(ConsumoCliente consumoCliente);
        Task<ConsumoCliente> FindById(int id);
        Task<ICollection<ConsumoCliente>> FindAll();
        Task Delete(int id);
        Task<ICollection<ConsumoCliente>> FindByIdCliente(int id);
    }
}
