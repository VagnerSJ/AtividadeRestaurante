using Atividade_PeDeFava.Context;
using Atividade_PeDeFava.Models;
using Atividade_PeDeFava.Repository.interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Atividade_PeDeFava.Repository.implementacoes
{
    public class R_Refeicao_ConsumoClienteRepository : GenericRepository<R_Refeicao_ConsumoCliente>, IR_Refeicao_ConsumoClienteRepository
    {
        public R_Refeicao_ConsumoClienteRepository(RestauranteContext context) : base(context)
        {
        }

        public override async Task<R_Refeicao_ConsumoCliente> FindById(int id)
        {
            return await _context.R_Refeicao_ConsumoCliente
                .Include(rCli => rCli.ConsumoCliente)
                .Include(rCli => rCli.Refeicao)
                .Where(rCli => rCli.Id.Equals(id))
                .SingleOrDefaultAsync();

           /* query = _context.R_Refeicao_ConsumoCliente
                .Include(rCon => rCon.ConsumoCliente)
                .Where(rCon => rCon.Id.Equals(id))
                .SingleOrDefaultAsync();

            query = _context.R_Refeicao_ConsumoCliente
                .Include(rRefe => rRefe.Refeicao)
                .Where(rRefe => rRefe.Id.Equals(id))
                .SingleOrDefaultAsync();

            return await query;*/
        }
    }
}
