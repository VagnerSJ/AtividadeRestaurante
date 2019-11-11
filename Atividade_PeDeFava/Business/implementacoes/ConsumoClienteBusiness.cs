using Atividade_PeDeFava.Business.interfaces;
using Atividade_PeDeFava.Models;
using Atividade_PeDeFava.Repository.interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atividade_PeDeFava.Business.implementacoes
{
    public class ConsumoClienteBusiness : IConsumoClienteBusiness
    {
        private IConsumoClienteRepository _repository;

        public ConsumoClienteBusiness(IConsumoClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<ConsumoCliente> Create(ConsumoCliente consumoCliente)
        {
            return await _repository.Create(consumoCliente);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<ICollection<ConsumoCliente>> FindAll()
        {
            return await _repository.FindAll();
        }

        public async Task<ConsumoCliente> FindById(int id)
        {
            return await _repository.FindById(id);
        }

        public async Task<ConsumoCliente> Update(ConsumoCliente consumoCliente)
        {
            return await _repository.Update(consumoCliente);
        }

        public async Task<ICollection<ConsumoCliente>> FindByIdCliente(int id)
        {
            return await _repository.FindByIdCliente(id);
        }
    }
}
