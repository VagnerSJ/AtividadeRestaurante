using Atividade_PeDeFava.Context;
using Atividade_PeDeFava.Models;
using Atividade_PeDeFava.Repository.interfaces;

namespace Atividade_PeDeFava.Repository.implementacoes
{
    public class TipoProdutoRepository : GenericRepository<TipoProduto>, ITipoProdutoRepository
    {
        public TipoProdutoRepository(RestauranteContext context) : base(context)
        {
        }
    }
}
