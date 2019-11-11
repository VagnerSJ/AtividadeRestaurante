using Atividade_PeDeFava.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atividade_PeDeFava.Business.interfaces
{
    public interface IClienteBusiness
    {
        Task<Cliente> Create(Cliente cliente);
        Task<Cliente> Update(Cliente cliente);
        Task<Cliente> FindById(int id);
        Task<ICollection<Cliente>> FindAll();
        Task Delete(int id);
    }
}
