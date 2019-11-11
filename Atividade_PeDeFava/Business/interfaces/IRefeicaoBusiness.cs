using Atividade_PeDeFava.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atividade_PeDeFava.Business.interfaces
{
    public interface IRefeicaoBusiness
    {
        Task<Refeicao> Create(Refeicao refeicao);
        Task<Refeicao> Update(Refeicao refeicao);
        Task<Refeicao> FindById(int id);
        Task<ICollection<Refeicao>> FindAll();
        Task Delete(int id);
    }
}
