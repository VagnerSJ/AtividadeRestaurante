using Atividade_PeDeFava.Business.interfaces;
using Atividade_PeDeFava.Models;
using Atividade_PeDeFava.Repository.interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade_PeDeFava.Business.implementacoes
{
    public class R_Refeicao_ConsumoClienteBusiness : IR_Refeicao_ConsumoClienteBusiness
    {
        private IR_Refeicao_ConsumoClienteRepository _repository;

        public R_Refeicao_ConsumoClienteBusiness(IR_Refeicao_ConsumoClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<R_Refeicao_ConsumoCliente> Create(R_Refeicao_ConsumoCliente r_Refeicao_ConsumoCliente)
        {
            return await _repository.Create(r_Refeicao_ConsumoCliente);
        }

        public async Task<R_Refeicao_ConsumoCliente> Update(R_Refeicao_ConsumoCliente r_Refeicao_ConsumoCliente)
        {
            return await _repository.Update(r_Refeicao_ConsumoCliente);
        }

        public async Task<R_Refeicao_ConsumoCliente> FindById(int id)
        {
            return await _repository.FindById(id);
        }

        public async Task<ICollection<R_Refeicao_ConsumoCliente>> FindAll()
        {
            return await _repository.FindAll();
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }
    }
}
