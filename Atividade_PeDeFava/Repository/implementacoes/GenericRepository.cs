using Atividade_PeDeFava.Context;
using Atividade_PeDeFava.Models.Base;
using Atividade_PeDeFava.Repository.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atividade_PeDeFava.Repository.implementacoes
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly RestauranteContext _context;
        protected DbSet<T> dataset;

        public GenericRepository(RestauranteContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }

        public async Task<T> Create(T item)
        {
            dataset.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task Delete(int id)
        {
            var resultado = await dataset.SingleOrDefaultAsync(i => i.Id.Equals(id));
            try
            {
                if (resultado == null)
                    throw new Exception("Item não encontrado na base de dados.");
                dataset.Remove(resultado);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ICollection<T>> FindAll()
        {
            return await dataset.ToListAsync();
        }

        public virtual async Task<T> FindById(int id)
        {
            return await dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
        }

        public async Task<T> Update(T item)
        {
            var resultado = await dataset.SingleOrDefaultAsync(i => i.Id.Equals(item.Id));
            try
            {
                if (resultado == null)
                    throw new Exception("O item informado não existe");
                _context.Entry(resultado).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
