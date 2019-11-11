using Atividade_PeDeFava.Context;
using Atividade_PeDeFava.Models;
using Atividade_PeDeFava.Repository.interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade_PeDeFava.Repository.implementacoes
{
    public class ConsumoClienteRepository : GenericRepository<ConsumoCliente>, IConsumoClienteRepository
    {
        public ConsumoClienteRepository(RestauranteContext context) : base(context)
        {
        }

        public async Task<ICollection<ConsumoCliente>> FindByIdCliente(int id)
        {
            var listaDeConsumoCliente = await dataset.ToListAsync();

            var listaDeConsumoClienteDoCliente = listaDeConsumoCliente.FindAll(i => i.ClienteId.Equals(id));

            return listaDeConsumoClienteDoCliente;
        }

        public override async Task<ConsumoCliente> FindById(int id)
        {
            return await _context.ConsumoCliente
                .Include(con => con.Cliente)
                .Where(con => con.Id.Equals(id))
                .SingleOrDefaultAsync();
        }
    }
}
