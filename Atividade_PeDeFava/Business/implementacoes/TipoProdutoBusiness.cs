using Atividade_PeDeFava.Business.interfaces;
using Atividade_PeDeFava.Models;
using Atividade_PeDeFava.Repository.interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atividade_PeDeFava.Business.implementacoes
{
    public class TipoProdutoBusiness : ITipoProdutoBusiness
    {
        private ITipoProdutoRepository _repository;

        public TipoProdutoBusiness(ITipoProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<TipoProduto> Create(TipoProduto tipoProduto)
        {
            return await _repository.Create(tipoProduto);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<ICollection<TipoProduto>> FindAll()
        {
            return await _repository.FindAll();
        }

        public async Task<TipoProduto> FindById(int id)
        {
            return await _repository.FindById(id);
        }

        public async Task<TipoProduto> Update(TipoProduto tipoProduto)
        {
            return await _repository.Update(tipoProduto);
        }
    }
}
