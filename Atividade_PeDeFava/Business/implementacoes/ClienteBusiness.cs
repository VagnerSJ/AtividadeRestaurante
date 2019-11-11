using Atividade_PeDeFava.Business.interfaces;
using Atividade_PeDeFava.Models;
using Atividade_PeDeFava.Repository.interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atividade_PeDeFava.Business.implementacoes
{
    public class ClienteBusiness : IClienteBusiness
    {
        private IClienteRepository _repository;

        public ClienteBusiness(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<Cliente> Create(Cliente clinte)
        {
            return await _repository.Create(clinte);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<ICollection<Cliente>> FindAll()
        {
            return await _repository.FindAll();
        }

        public async Task<Cliente> FindById(int id)
        {
            return await _repository.FindById(id);
        }

        public async Task<Cliente> Update(Cliente cliente)
        {
            return await _repository.Update(cliente);
        }
    }
}
