using Atividade_PeDeFava.Business.interfaces;
using Atividade_PeDeFava.Models;
using Atividade_PeDeFava.Repository.interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atividade_PeDeFava.Business.implementacoes
{
    public class RefeicaoBusiness : IRefeicaoBusiness
    {
        private IRefeicaoRepository _repository;

        public RefeicaoBusiness(IRefeicaoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Refeicao> Create(Refeicao refeicao)
        {
            return await _repository.Create(refeicao);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<ICollection<Refeicao>> FindAll()
        {
            return await _repository.FindAll();
        }

        public async Task<Refeicao> FindById(int id)
        {
            return await _repository.FindById(id);
        }

        public async Task<Refeicao> Update(Refeicao refeicao)
        {
            return await _repository.Update(refeicao);
        }
    }
}
