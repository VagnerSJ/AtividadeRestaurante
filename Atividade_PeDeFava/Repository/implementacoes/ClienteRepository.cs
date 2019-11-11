using Atividade_PeDeFava.Context;
using Atividade_PeDeFava.Models;
using Atividade_PeDeFava.Repository.interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade_PeDeFava.Repository.implementacoes
{
    public class ClienteRepository : GenericRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(RestauranteContext context) : base(context)
        {
        }
    }
}
