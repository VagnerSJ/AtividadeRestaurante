using Atividade_PeDeFava.Context;
using Atividade_PeDeFava.Models;
using Atividade_PeDeFava.Repository.interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade_PeDeFava.Repository.implementacoes
{
    public class RefeicaoRepository : GenericRepository<Refeicao>, IRefeicaoRepository
    {
        public RefeicaoRepository(RestauranteContext context) : base(context){}

        public override async Task<Refeicao> FindById(int id)
        {
            return await _context.Refeicao
                .Include(refe => refe.TipoProduto)
                .Where(refe => refe.Id.Equals(id))
                .SingleOrDefaultAsync();
        }
    }
}
