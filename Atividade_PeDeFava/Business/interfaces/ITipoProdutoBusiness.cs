using Atividade_PeDeFava.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atividade_PeDeFava.Business.interfaces
{
    public interface ITipoProdutoBusiness
    {
        Task<TipoProduto> Create(TipoProduto refeicao);
        Task<TipoProduto> Update(TipoProduto refeicao);
        Task<TipoProduto> FindById(int id);
        Task<ICollection<TipoProduto>> FindAll();
        Task Delete(int id);
    }
}
